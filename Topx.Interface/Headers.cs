using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.Interface
{
    public class Headers
    {
        private readonly TOPX_GenericEntities _entities;
        private enum MappingType { DOSSIER, RECORD, BESTAND}

        private readonly List<FieldMapping> _headersDossiers;
        private readonly List<FieldMapping> _headersRecords;
        private readonly List<FieldMapping> _headersBestanden;

        public List<FieldMapping> HeadersRecordsBestanden =>  _headersRecords.Concat(_headersBestanden) .ToList();

        public Headers(TOPX_GenericEntities entities)
        {
            _entities = entities;
            var propertyInfosDossiers = new Dossier().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                       BindingFlags.Public |
                                                       BindingFlags.Instance) ;

            _headersDossiers = GetPropertyInfoNames(propertyInfosDossiers);

            var propertyInfosRecords= new Record().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                       BindingFlags.Public |
                                                                       BindingFlags.Instance);

            _headersRecords = GetPropertyInfoNames(propertyInfosRecords);

            var propertyInfosBestand = new Bestand().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                             BindingFlags.Public |
                                                                             BindingFlags.Instance);

            _headersBestanden = GetPropertyInfoNames(propertyInfosBestand);

        }

        private List<FieldMapping> GetPropertyInfoNames(PropertyInfo[] propertyInfos)
        {
            var listOfFields = propertyInfos.Where(propertyInfo => propertyInfo.Name != "Id" && propertyInfo.Name != "DossierId").Select(propertyInfo => propertyInfo.Name);

            return listOfFields.Select(listOfField => new FieldMapping() {DatabaseFieldName = listOfField}).ToList();
        }

        public List<FieldMapping> GetHeaderMappingDossiers(List<string> sourceHeaders)
        {
           foreach (var sourceHeader in sourceHeaders)
           {
               var headersDossier = _headersDossiers.FirstOrDefault(t => t.DatabaseFieldName == sourceHeader);
               if (headersDossier != null)
                   headersDossier.MappedFieldName = sourceHeader;
               else
               {
                   _headersDossiers.Add(new FieldMapping() { MappedFieldName = sourceHeader});
               }
              
            }
            return _headersDossiers;
        }

        public List<FieldMapping> GetHeaderMappingRecordsBestanden(List<string> sourceHeaders)
        {
            foreach (var sourceHeader in sourceHeaders)
            {
                var headerRecords = _headersRecords.FirstOrDefault(t => t.DatabaseFieldName == sourceHeader);
                if (headerRecords != null)
                    headerRecords.MappedFieldName = sourceHeader;
                else
                {
                    _headersRecords.Add(new FieldMapping() { MappedFieldName = sourceHeader });
                }

            }
            return _headersRecords;
        }
    }
}

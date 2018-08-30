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
        public List<string> HeadersDossiers;
        public List<string> HeadersRecords;
        public List<string> HeadersBestanden;

        public List<string> HeadersRecordsBestanden =>  HeadersRecords.Concat(HeadersBestanden) .ToList();

        public Headers(TOPX_GenericEntities entities)
        {
            _entities = entities;
            var propertyInfosDossiers = new Dossier().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                       BindingFlags.Public |
                                                       BindingFlags.Instance) ;

            HeadersDossiers = GetPropertyInfoNames(propertyInfosDossiers);

            var propertyInfosRecords= new Record().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                       BindingFlags.Public |
                                                                       BindingFlags.Instance);

            HeadersRecords = GetPropertyInfoNames(propertyInfosRecords);

            var propertyInfosBestand = new Bestand().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                             BindingFlags.Public |
                                                                             BindingFlags.Instance);

            HeadersBestanden = GetPropertyInfoNames(propertyInfosBestand);

        }

        private List<string> GetPropertyInfoNames(PropertyInfo[] propertyInfos)
        {
            return (from propertyInfo in propertyInfos where propertyInfo.Name != "Id" select propertyInfo.Name).ToList();
        }

        public List<FieldMapping> GetHeaderMappingDossiers(List<string> sourceHeaders)
        {
            var fieldmappings = new List<FieldMapping>();
            foreach (var sourceHeader in sourceHeaders)
            {
                fieldmappings.Add(new FieldMapping()
                {
                    MappedFieldName = sourceHeader,
                    DatabaseFieldName = HeadersDossiers.Find(t => t == sourceHeader)
                });
            }
            return fieldmappings;
        }

        public List<FieldMapping> GetHeaderMappingRecordsBestanden(List<string> sourceHeaders)
        {
            var fieldmappings = new List<FieldMapping>();
            foreach (var sourceHeader in sourceHeaders)
            {
                fieldmappings.Add(new FieldMapping()
                {
                    MappedFieldName = sourceHeader,
                    DatabaseFieldName = HeadersRecordsBestanden.Find(t => t == sourceHeader)
                });
            }
            return fieldmappings;
        }
    }
}

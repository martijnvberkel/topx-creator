using System;
using System.Collections;
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
        //private readonly ModelTopX _entities;
        

        private List<FieldMapping> _headersDossiers;
        private List<FieldMapping> _headersRecords;
        private readonly List<FieldMapping> _headersBestanden;
        private List<FieldMapping> _headerMappingRecordsBestanden;

        public List<FieldMapping> HeadersRecordsBestanden => _headersRecords.Concat(_headersBestanden).ToList();

        public Headers()
        {
            //_entities = entities;
        }

        private void CreateListOfAvailableColumnsOfDossiers()
        {
            var propertyInfosDossiers = new Dossier().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                              BindingFlags.Public |
                                                                              BindingFlags.Instance);

            _headersDossiers = GetPropertyInfoNames(propertyInfosDossiers, FieldMappingType.DOSSIER);
        }

        private void CreateListOfAvailableColumnsOfRecords()
        {
            var propertyInfosRecords = new Record().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                            BindingFlags.Public |
                                                                            BindingFlags.Instance);

            _headersRecords = GetPropertyInfoNames(propertyInfosRecords, FieldMappingType.RECORD);
        }


        private List<FieldMapping> GetPropertyInfoNames(PropertyInfo[] propertyInfos, FieldMappingType type)
        {
            // if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
            var listOfFields = propertyInfos.Where
            (
                propertyInfo =>
                    propertyInfo.Name != "Id" && propertyInfo.Name !="Dossiers" && propertyInfo.Name != "Records" && propertyInfo.Name != "Bestanden"
                    && !HeaderClassification.OptionalHeaders.Contains(propertyInfo.Name)
                    && propertyInfo.PropertyType != typeof(ICollection<>)


            //&& (
            //    propertyInfo.PropertyType == typeof(string) 
            //    || propertyInfo.PropertyType == typeof(int) 
            //    || propertyInfo.PropertyType == typeof(Int64) 
            //    || propertyInfo.PropertyType == typeof(DateTime)
            //    )  // prevent navigation properties
            )
            .Select(propertyInfo => propertyInfo.Name);
            return listOfFields.Select(listOfField => new FieldMapping() { DatabaseFieldName = listOfField, Type = type.ToString() }).ToList();
        }

        public List<FieldMapping> GetHeaderMappingDossiers(List<string> sourceHeaders)
        {
            CreateListOfAvailableColumnsOfDossiers();
            foreach (var sourceHeader in sourceHeaders)
            {
                var headersDossier = _headersDossiers.FirstOrDefault(t => t.DatabaseFieldName == sourceHeader);
                if (headersDossier != null)
                {
                    headersDossier.MappedFieldName = sourceHeader;
                    headersDossier.Type = FieldMappingType.DOSSIER.ToString();
                }
                else
                {
                    _headersDossiers.Add(new FieldMapping() {MappedFieldName = sourceHeader, Type = FieldMappingType.RECORD.ToString() });
                }

            }
            return _headersDossiers;
        }

        public List<FieldMapping> GetHeaderMappingRecordsBestanden(List<string> sourceHeaders)
        {
           CreateListOfAvailableColumnsOfRecords();
           foreach (var sourceHeader in sourceHeaders)
            {
                var headerRecords = _headersRecords.FirstOrDefault(t => t.DatabaseFieldName == sourceHeader);
                if (headerRecords != null)
                {
                    headerRecords.MappedFieldName = sourceHeader;
                    headerRecords.Type = FieldMappingType.RECORD.ToString();
                }
                else
                {
                    _headersRecords.Add(new FieldMapping() { MappedFieldName = sourceHeader, Type = FieldMappingType.DOSSIER.ToString() });
                }

            }
            return _headersRecords;
        }
    }
}

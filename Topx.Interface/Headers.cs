using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
        private List<TopX_AdditionalParameters> _topX_Tmlos;

        //public List<FieldMapping> HeadersRecordsBestanden => _headersRecords.Concat(_headersBestanden).ToList();

        public Headers()
        {
            var resourceHelper = new ResourceHelper();
            _topX_Tmlos = resourceHelper.GetTopX_TMLO();
        }

        public void CreateListOfAvailableColumnsOfDossiers()
        {
            var propertyInfosDossiers = new Dossier().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                              BindingFlags.Public |
                                                                              BindingFlags.Instance);

            _headersDossiers = GetPropertyInfoNames(propertyInfosDossiers, FieldMappingType.DOSSIER);

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["UseComplexLinkNummer"]))
                _headersDossiers.Add(new FieldMapping() { DatabaseFieldName = "ComplexlinkNummer (optioneel)" });

            foreach (var headersDossier in _headersDossiers)
            {
                var topx_AdditionalParameters = (from t in _topX_Tmlos where t.TopX == headersDossier.DatabaseFieldName select t).FirstOrDefault();

                if (topx_AdditionalParameters != null)
                {
                    headersDossier.TMLO = topx_AdditionalParameters.TMLO;
                    headersDossier.Optional = topx_AdditionalParameters.Optional;
                }
            }

        }

        public void CreateListOfAvailableColumnsOfRecords()
        {
            var propertyInfosRecords = new Record().GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                            BindingFlags.Public |
                                                                            BindingFlags.Instance);

            _headersRecords = GetPropertyInfoNames(propertyInfosRecords, FieldMappingType.RECORD);
            foreach (var headersRecord in _headersRecords)
            {
                var topx_AdditionalParameters = (from t in _topX_Tmlos where t.TopX == headersRecord.DatabaseFieldName select t).FirstOrDefault();
                headersRecord.TMLO = topx_AdditionalParameters.TMLO;
                headersRecord.Optional = topx_AdditionalParameters.Optional;
            }
        }



        private List<FieldMapping> GetPropertyInfoNames(PropertyInfo[] propertyInfos, FieldMappingType type)
        {
            // if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
            var listOfFields = propertyInfos.Where
            (
                propertyInfo => 
                (
                propertyInfo.PropertyType == typeof(string) || 
                propertyInfo.PropertyType == typeof(Int64?) || 
                propertyInfo.PropertyType == typeof(DateTime?)
                )
                    && !HeaderClassification.OptionalHeaders.Contains(propertyInfo.Name)
                    && propertyInfo.PropertyType != typeof(ICollection<>))
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
                    _headersDossiers.Add(new FieldMapping() { MappedFieldName = sourceHeader, Type = FieldMappingType.RECORD.ToString() });
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HTCore.Models;
using HTCore.Repository;

namespace HTApplication.Service
{
    public class ImportService
    {

        public static ImportService CreateForEF() {
            return new ImportService(new EFOpenDataRepository());
        }

        public IOpenDataRepository Repository { get; set; }
        private ImportService(EFOpenDataRepository repository) { Repository = repository; }

        public List<OpenData> FindOpenDataFromXml()
        {
            List<OpenData> result = new List<OpenData>();

            string baseDir = Directory.GetCurrentDirectory();



            var xml = XElement.Load(@"C: \Users\user\source\repos\NKUST10712\1018\資料庫操作\OpenDataImport\App_Data\20190109193732MFDir.xml");



            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var nodes = xml.Descendants("node").ToList();


            result = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.id = int.Parse(getValue(node, "id"));
                    item.園區別 = getValue(node, "園區別");
                    item.廠商名稱 = getValue(node, "廠商名稱");
                    item.地址 = getValue(node, "地址");
                    return item;
                }).ToList();
            return result;

        }
        public List<OpenData> FindOpenDataFromDb(string name = null)
        {
            return Repository.SelectAll(name);
        }


        public void ImportToDb(List<OpenData> openDatas)
        {

            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });

        }
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();

        }

    }
}

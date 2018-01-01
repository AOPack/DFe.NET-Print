﻿using System;
using System.Xml;
using System.Xml.Linq;

namespace DFe.Print.Core
{
    public class NFePrinter : IHtmlRawGenerator
    {
        public XElement ApplyCssBase()
        {
            //body {
            //    background: rgb(204, 204, 204);
            //}
            //page {
            //    background: white;
            //    display: block;
            //    margin: 0 auto;
            //    margin - bottom: 0.5cm;
            //    box - shadow: 0 0 0.5cm rgba(0,0,0,0.5);
            //}
            //page[size = "A4"] {
            //    width: 21cm;
            //    height: 29.7cm;
            //}
            //page[size = "A4"][layout = "portrait"] {
            //    width: 29.7cm;
            //    height: 21cm;
            //}
            //page[size = "A3"] {
            //    width: 29.7cm;
            //    height: 42cm;
            //}
            //page[size = "A3"][layout = "portrait"] {
            //    width: 42cm;
            //    height: 29.7cm;
            //}
            //page[size = "A5"] {
            //    width: 14.8cm;
            //    height: 21cm;
            //}
            //page[size = "A5"][layout = "portrait"] {
            //    width: 21cm;
            //    height: 14.8cm;
            //}
            //@media print {
            //    body, page {
            //        margin: 0;
            //        box - shadow: 0;
            //    }
            //}

            return null;
        }

        public XElement GetContent(NFe data)
        {
            return new XElement("content");
        }

        public XElement GetFooter(NFe data)
        {
            return new XElement("footer");
        }

        public XElement GetHeader(NFe data)
        {
            return new XElement("header",
                new XElement("div",
                new XElement("p", data.ChaveAcesso)));
        }

        public XDocument ToHtml(NFe data)
        {
            var xDocument = new XDocument(
                new XDocumentType("html", null, null, null),
                new XElement("html",
                    new XElement("head"),
                    new XElement("body",
                        new XElement(GetHeader(data)),
                        new XElement(GetContent(data)),
                        new XElement(GetFooter(data)))));

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                IndentChars = "\t"
            };

            //using (var writer = XmlWriter.Create(path, settings))
            //{
            //    xDocument.WriteTo(writer);
            //}

            return xDocument;
        }
    }
}

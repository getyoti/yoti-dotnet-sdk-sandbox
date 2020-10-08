using System;
using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskBuilder : SandboxTaskResult
    {
        private Dictionary<string, object> _documentFields;
        private SandboxDocumentFilter _documentFilter;
        private SandboxDocumentIdPhoto _documentIdPhoto;

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentField(string key, object value)
        {
            if (_documentFields == null)
            {
                _documentFields = new Dictionary<string, object>();
            }
            _documentFields.Add(key, value);
            return this;
        }

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentFilter(SandboxDocumentFilter documentFilter)
        {
            _documentFilter = documentFilter;
            return this;
        }

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentIdPhoto(string contentType, byte[] documentIdPhoto)
        {
            string base64DocumentIdPhoto = Convert.ToBase64String(documentIdPhoto);
            _documentIdPhoto = new SandboxDocumentIdPhoto(contentType, base64DocumentIdPhoto);
            return this;
        }

        public SandboxDocumentTextDataExtractionTask Build()
        {
            SandboxDocumentTextDataExtractionTaskResult result = new SandboxDocumentTextDataExtractionTaskResult(_documentFields, _documentIdPhoto);
            return new SandboxDocumentTextDataExtractionTask(result, _documentFilter);
        }
    }
}
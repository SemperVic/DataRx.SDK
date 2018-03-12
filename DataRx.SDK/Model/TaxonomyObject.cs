using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Common;

namespace DataRx.SDK.Model
{
    /// <summary>
    /// TODO: Code commentary
    /// </summary>
    public class TaxonomyObjectBase : DataTransferObject
    {
        private String taxKey = String.Empty;
        private String superKey = String.Empty;
        private String indexName = String.Empty;
        private String targetMdr = String.Empty;
        private String mdrKey = String.Empty;
        private String mdrSuperKey = String.Empty;
        private String mdrLexicon = String.Empty;
        private String taxStandard = String.Empty;
        private String shortDesc = String.Empty;
        private String author = String.Empty;

        /// <summary>
        /// TODO
        /// </summary>
        public String TaxKey
        {
            get { return this.taxKey; }
            set
            {
                this.taxKey = value;
                if(this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String SuperKey
        {
            get { return this.superKey; }
            set
            {
                this.superKey = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String IndexName
        {
            get { return this.indexName; }
            set
            {
                this.indexName = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String TargetMDR
        {
            get { return this.targetMdr; }
            set
            {
                this.targetMdr = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String MDRKey
        {
            get { return this.mdrKey; }
            set
            {
                this.mdrKey = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String MDRSuperKey
        {
            get { return this.mdrSuperKey; }
            set
            {
                this.mdrSuperKey = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String MDRLexicon
        {
            get { return this.mdrLexicon; }
            set {
                this.mdrLexicon = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String TaxStandard
        {
            get { return this.taxStandard; }
            set
            {
                this.taxStandard = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
        /// <summary>
        /// TODO
        /// </summary>
        public String ShortDesc
        {
            get { return this.shortDesc; }
            set
            {
                this.shortDesc = value;
                if (this.ObjectState.Equals(DTOState.Clean))
                {
                    this.ObjectState = DTOState.Dirty;
                }
            }
        }
    }

    public class TaxonomyObject : TaxonomyObjectBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaxonomyObject() { /* Do Nothing */ }
        /// <summary>
        /// 
        /// </summary>
        public TaxonomyObject(String taxKey, String superKey, String indexName, String targetMdr, String mdrKey, String mdrSuperKey, String mdrLexicon, String taxStandard, String shortDesc, String author)
        {
            this.TaxKey = taxKey;
            this.SuperKey = superKey;
            this.IndexName = indexName;
            this.TargetMDR = targetMdr;
            this.MDRKey = mdrKey;
            this.MDRSuperKey = mdrSuperKey;
            this.MDRLexicon = mdrLexicon;
            this.TaxStandard = taxStandard;
            this.ShortDesc = shortDesc;
            //this.Author = author;
        }
    }


}

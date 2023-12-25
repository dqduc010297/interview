using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.EM.Services.Abstraction
{
    public class PaginationRequest
    {
        protected int _pageNumber;
        protected int _rowsPerPage;
        public string SearchTerm { set; get; }
        public virtual int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("PageNumber must be than zero");
                }
                this._pageNumber = value;
            }
        }
        public virtual int RowsPerPage
        {
            get { return this._rowsPerPage; }
            set
            {
                if (value < 1 || value > 999)
                { throw new ArgumentOutOfRangeException("RowsPerPage"); }
                _rowsPerPage = value;
            }
        }
        public virtual int SkipCount
        {
            get
            {
                return (this.PageNumber <= 1 ? 0 : this.PageNumber - 1) * this.TakeCount;
            }
        }
        public virtual int TakeCount
        {
            get
            {
                return this.RowsPerPage <= 0 ? 10 : this.RowsPerPage;
            }
        }
    }
}

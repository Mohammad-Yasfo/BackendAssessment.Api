using BackendAssessment.Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace BackendAssessment.Application.Common.Extensions
{
    public static class PaginationExtensions
    {
        /// <summary>
        /// You should pass the list contains one item plus more than page size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">the current list contains one item plus than page size</param>
        /// <param name="currentPageIndex">the current page index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="httpContextAccessor">Reference to httpContextAccessor </param>
        /// <returns></returns>
        public static PaginatedDto<T> ToPagedList<T>(this IEnumerable<T> list, int currentPageIndex, int pageSize,
           IHttpContextAccessor httpContextAccessor)
        {
            //check if this last page
            bool isLastPage = true;

            if (list.Count() > pageSize)
            {
                isLastPage = false;
                //skip the last item
                list = list.SkipLast(1);
            }

            //Initiate the list
            PaginatedDto<T> pagedList = new PaginatedDto<T>() { Items = list };

            //Get the paginations urls
            Pagination page = GetAbsoluteUri(httpContextAccessor, currentPageIndex,
                pageSize, isLastPage);

            pagedList.Pagination = page;

            return pagedList;
        }
        private static Pagination GetAbsoluteUri(IHttpContextAccessor httpContextAccessor,
            int cuurentPageIndex, int pageSize, bool isLastPage)
        {
            //Build Url using request object in http context
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = httpContextAccessor.HttpContext.Request.Scheme;
            //Getting the host value with port will add brackets [], get them in separate lines
            uriBuilder.Host = httpContextAccessor.HttpContext.Request.Host.Host;
            if (httpContextAccessor.HttpContext.Request.Host.Port.HasValue)
                uriBuilder.Port = httpContextAccessor.HttpContext.Request.Host.Port.Value;
            uriBuilder.Path = httpContextAccessor.HttpContext.Request.Path.ToString();

            //Getting the current query strings, and remove the current pageindex and pagesize
            var query = httpContextAccessor.HttpContext.Request.Query
                .Where(q => q.Key.ToLower() != "pageindex" && q.Key.ToLower() != "pagesize");

            //Keep the old query strings if any (like search..)
            string baseQuery = "?";
            foreach (var kv in query)
                baseQuery += $"{kv.Key}={kv.Value}&";

            //build the new query strings
            string
                firstPageQueryString = string.Empty,
                nextPageQueryString = string.Empty,
                prevPageQueryString = string.Empty;

            firstPageQueryString = baseQuery + $"PageIndex=1&PageSize={pageSize}";
            if (!isLastPage)
                nextPageQueryString = baseQuery + $"PageIndex={cuurentPageIndex + 1}&PageSize={pageSize}";
            if (cuurentPageIndex > 1)
                prevPageQueryString = baseQuery + $"PageIndex={cuurentPageIndex - 1}&PageSize={pageSize}";

            //Build the final Urls
            string baseUrl = uriBuilder.ToString();
            var page = new Pagination();
            page.FirstPageUrl = baseUrl + firstPageQueryString;
            if (!string.IsNullOrEmpty(nextPageQueryString))
                page.NextPageUrl = baseUrl + nextPageQueryString;
            if (!string.IsNullOrEmpty(prevPageQueryString))
                page.PrevPageUrl = baseUrl + prevPageQueryString;

            return page;
        }
    }
}
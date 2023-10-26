using JsonApiDotNetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Domain.AggregatesModel;

public class PagedList
{
    public int CurrentPage { get; private set; }
    public int TotalItem { get; private set;}
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public PagedList() { }
    public PagedList( int totalItem, int page, int pageSize=10)
    {
        int totalPages = (int)Math.Ceiling(((decimal)totalItem / (decimal)pageSize));
        int currentPage = page;
        int startPage = currentPage - 5;
        int endPage = currentPage + 4;
        if(startPage <=0)
        {
            endPage=endPage-(startPage-1);
            startPage = 1;
        }
        if(endPage>totalPages)
        {
            endPage = totalPages;
            if (endPage > 10)
            {
                startPage = endPage - 9;
            }
        }
        TotalItem= totalItem;
        CurrentPage = currentPage;
        PageSize= pageSize;
        TotalPages = totalPages;
        StartPage=startPage;
        EndPage=endPage;
    }

}

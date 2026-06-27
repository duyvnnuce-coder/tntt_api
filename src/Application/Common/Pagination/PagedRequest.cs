using Application.Common.Constants;

namespace Application.Common.Pagination;

public class PagedRequest
{
    private int _page = AppConstants.DefaultPage;
    private int _pageSize = AppConstants.DefaultPageSize;

    public int Page
    {
        get => _page;
        set => _page = value <= 0
            ? AppConstants.DefaultPage
            : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value <= 0)
                _pageSize = AppConstants.DefaultPageSize;
            else if (value > AppConstants.MaxPageSize)
                _pageSize = AppConstants.MaxPageSize;
            else
                _pageSize = value;
        }
    }

    public string? Keyword { get; set; }
}
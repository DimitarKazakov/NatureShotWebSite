(function ($) {
    "use strict";

    document.querySelector('#orderByDropDown').addEventListener('click', submitForm);

    function submitForm(e) {
        console.log('click');
        if (e.target.tagName == 'A') {
            const paramsInUrl = new URLSearchParams(window.location.search);
            let searchByParam = paramsInUrl.get('searchBy');
            let searchInputParam = paramsInUrl.get('searchInput');

            if (searchByParam !== null && searchInputParam !== null) {
                searchByParam = encodeURIComponent(searchByParam);
                searchInputParam = encodeURIComponent(searchInputParam);

                const href = e.target.getAttribute('href');
                e.target.setAttribute('href', href + '?searchBy=' + searchByParam + '&searchInput=' + searchInputParam);
            }
        }
    }
})(jQuery);
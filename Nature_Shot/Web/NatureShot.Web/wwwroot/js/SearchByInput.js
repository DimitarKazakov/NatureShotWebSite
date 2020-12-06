(function ($) {
    "use strict";

    document.querySelector('#dropdownSearch').addEventListener('click', changeActiveSearch);
    const spanSearch = document.querySelector('#spanSearch');
    const searchByInput = document.querySelector('#searchByInputHidden');

    function changeActiveSearch(e) {
        const currentActive = document.querySelector('#dropdownSearch a.active');
        const target = e.target;

        if (target.tagName == 'A') {
            spanSearch.textContent = target.textContent;
            currentActive.classList.remove('active');
            target.classList.add('active');
            searchByInput.setAttribute('value', target.textContent);
        }
    }
})(jQuery);

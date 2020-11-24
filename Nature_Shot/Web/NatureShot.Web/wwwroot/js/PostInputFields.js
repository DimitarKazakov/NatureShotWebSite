(function ($) {
    "use strict";

    // tags input

    const selectTag = document.querySelector('#tagSelect');
    selectTag.addEventListener('change', putIntoTagInput);
    const inputTag = document.querySelector('#tagInput');

    function putIntoTagInput(e) {

        const selected = document.querySelectorAll('#tagSelect option:checked');
        const values = Array.from(selected).map(el => el.text);
        inputTag.value = values.join(' ');

    }

})(jQuery);
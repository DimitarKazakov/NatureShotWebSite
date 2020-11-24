(function ($) {
    "use strict";

    // town country inputs

    const locationDropDown = document.querySelector('#locationDropDown');
    const townInput = document.querySelector('#townInput');
    const countryInput = document.querySelector('#countryInput');
    locationDropDown.addEventListener('change', putInfoInInput)

    function putInfoInInput(e) {
        let currentSelection = e.target.selectedIndex;
        let currentSelectionName = e.target.options[currentSelection].textContent;

        let locationName = currentSelectionName.split('/');
        if (locationName.length > 2) {
            let town = locationName[0];

            for (let i = 1; i < locationName.length - 1; i++) {
                town += '/' + locationName[i];
            }

            const country = locationName[locationName.length - 1];

            townInput.value = town;
            countryInput.value = country;
        }
        else {
            const town = locationName[0];
            const country = locationName[1];

            townInput.value = town;
            countryInput.value = country;
        }
    }

    // tags input

    const selectTag = document.querySelector('#tagSelect');
    selectTag.addEventListener('change', putIntoTagInput);
    const inputTag = document.querySelector('#tagInput');

    function putIntoTagInput(e) {

        const selected = document.querySelectorAll('#tagSelect option:checked');
        const values = Array.from(selected).map(el => el.text);
        inputTag.value = values.join(' ');

    }

    // camera input

    const cameraInput = document.querySelector('#cameraInput');
    const cameraDropDown = document.querySelector('#cameraSelect');
    cameraDropDown.addEventListener('change', putIntoCameraInput);

    function putIntoCameraInput(e) {
        let currentSelection = e.target.selectedIndex;
        let currentSelectionName = e.target.options[currentSelection].textContent;

        cameraInput.value = currentSelectionName;
    }

    // file input

    const fileInput = document.querySelector('#fileInput');
    const fileInputLabel = document.querySelector('#fileLabel');
    fileInput.addEventListener('change', putIntoFileInput);

    function putIntoFileInput() {
        let fileName = fileInput.value.split('\\');
        fileInputLabel.textContent = fileName[fileName.length - 1];
    }

})(jQuery);
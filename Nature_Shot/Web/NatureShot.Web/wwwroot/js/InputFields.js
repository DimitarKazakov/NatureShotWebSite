(function ($) {
    "use strict";

    // town country inputs

    const locationDropDown = document.querySelector('#locationDropDown');
    const townInput = document.querySelector('#townInput');
    const countryInput = document.querySelector('#countryInput');
    locationDropDown.addEventListener('change', putInfoInInput)

    function putInfoInInput(e) {
        let locationName = e.target.value.split('/');
        const town = locationName[0];
        const country = locationName[1];

        townInput.value = town;
        countryInput.value = country;
    }

    // tags input

    const selectTag = document.querySelector('#tagSelect');
    selectTag.addEventListener('change', putIntoTagInput);
    const inputTag = document.querySelector('#tagInput');

    function putIntoTagInput() {

        for (let option of selectTag.options) {
            let optionValue = option.value;
            if (option.selected) {
                if (!inputTag.value.includes(optionValue)) {
                    inputTag.value += ' ' + optionValue;
                }
            }
            else {
                if (inputTag.value.includes(optionValue)) {

                    inputTag.value = inputTag.value.replace(' ' + optionValue, '');
                }
            }
        }
    }

    // camera input

    const cameraInput = document.querySelector('#cameraInput');
    const cameraDropDown = document.querySelector('#cameraSelect');
    cameraDropDown.addEventListener('change', putIntoCameraInput);

    function putIntoCameraInput(e) {
        let cameraName = e.target.value;

        cameraInput.value = cameraName;
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
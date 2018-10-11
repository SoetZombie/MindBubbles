//number2 after variables means 2nd level variable - inner inner one.
function addHorizontalLines() {
    let line, cell, line2, cell2;
    let element = $('.inner-line');
    let element2 = $('.inner-line2')
    element.each(function (i, l) {

        let line = $(l).children('.line');
        let cell = $(l).children('.cell')

        let heigth = (cell.outerHeight(true));
        line.css('height', (heigth / 2));

    });
    element2.each(function (i, l) {

        let line2 = $(l).children('.line2');
        let cell2 = $(l).children('.cell2')

        let heigth2 = (cell2.outerHeight(true));
        line2.css('height', (heigth2 / 2));

    });
}

function addVerticalLines() {
    let column = $('.column');
    let finalHeight;
    column.each(function (i, l) {
        let columnHeight = $(l).outerHeight(true);
        let lastCell = $(l).find('.cell').last();
        let lastInnerLine = $(l).find('.inner-line').last();

        let lastElHeight = lastCell.outerHeight(true);
        
        if ($(l).find('.cell').length === 1) {
            finalHeight = lastElHeight / 2 + 12;
        }
        if (lastInnerLine.children('.column2').length > 0) {
            console.log('a');
            let lastInnerLineHeight = lastInnerLine.find('.column2').outerHeight(true);
            finalHeight = (columnHeight - lastInnerLineHeight - lastElHeight / 2);
        }
        else {
            finalHeight = (columnHeight - lastElHeight / 2);
        } 
        let line = $('.line-column:eq(' + i + ')');
        line.css("height", finalHeight);
    });
    // inner inner verticals add - keeping in one method for simplicity
    let column2 = $('.column2');
    let finalHeight2;
    column2.each(function (i, l) {
        let columnHeight2 = $(l).outerHeight(true);
        let lastElHeight2 = $(l).find('.cell2').last().outerHeight(true);

        if ($(l).find('.cell2').length === 1) {
            finalHeight2 = lastElHeight2 / 2;
        }
        else {
            finalHeight2 = (columnHeight2 - lastElHeight2 / 2);
        }
        let line2 = $('.line-column2:eq(' + i + ')');
        line2.css("height", finalHeight2);
    });
}

function calculateLayout() {
    let divider = $(".column-heading").length;
    if (divider > 6) { divider = 6 };
    $('.column-parent').css('width', `${90 / divider}%`);
}

$(document).ready(function () {
    let changerObjects = $('.color-change');
    let columnHeading = $('.column-heading');
    let color;

    calculateLayout();
    addHorizontalLines();
    addVerticalLines();

    $(".color-picker").click(function () {
        color = $(this).data('color');
        changerObjects.each(function (i, v) {
            $(v).css("border-color", color);
        });
        columnHeading.css("background-color", color);

    });
    $(".correction-button-plus").click(function () {
        let px = $('#px-correction').val() -1;
        let lineCorr = $('.line-column:eq(' + px + ')');
        let height = lineCorr.outerHeight(true);
        lineCorr.css("height", height + 1);
        console.log(height);

    });

    $(".correction-button-").click(function () {
        let px = $('#px-correction').val() - 1;
        let lineCorr = $('.line-column:eq(' + px + ')');
        let height = lineCorr.outerHeight(true);
        lineCorr.css("height", height - 1);
    });

});



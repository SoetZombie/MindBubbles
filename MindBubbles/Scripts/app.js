function addHorizontalLines() {
    let line, cell;
    let element = $('.inner-line');
    element.each(function (i, l) {

        let line = $(l).children('.line');
        let cell = $(l).children('.cell')

        let heigth = (cell.outerHeight(true));
        line.css('height', (heigth / 2));

    });
}

function addVerticalLines() {
    let column = $('.column');
    let finalHeight;
    const rowHeight = $('.row').first().outerHeight(true);
    column.each(function (i, l) {
        let columnHeight = $(l).outerHeight(true);
        let lastElHeight = $(l).find('.cell').last().outerHeight(true);
        
        if ($(l).find('.cell').length === 1) {
            finalHeight = lastElHeight / 2 + 12;
        }
        else {
            finalHeight = (columnHeight - lastElHeight / 2);
        } 
        let line = $('.line-column:eq(' + i + ')');
        line.css("height", finalHeight);
        console.log(finalHeight);
        console.log(columnHeight);
        console.log(lastElHeight);
    });
    
}

function calculateLayout() {
    let divider = $(".column-heading").length;

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



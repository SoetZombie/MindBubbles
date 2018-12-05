//number2 after variables means 2nd level variable - inner inner one.
let divider;
let finalHeight;

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
        line2.css('height', (heigth2 / 2) + 6);

    });
}

function addVerticalLines() {
    column = $('.column');
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
        line2.css("height", finalHeight2 + 6);
    });
}

function calculateLayout() {
    let headingsHeights = [];
    headings = $(".column-heading")
    divider = headings.length;
    if (divider > 6) { divider = 6 };
    if (divider < 4) { divider = 4 };
    $('.column-parent').css('width', `${95 / divider}%`);
    headings.each(function (i, o) {
        headingsHeights.push($(o).outerHeight(true));
    });
    headingsHeights.sort(function (a, b) {
        return a - b;
    });
    $(".column-heading").css('height', headingsHeights.slice(-1)[0]);
 
}

function shiftClonedIfLast() {
    let allColumns = $(".column-parent");
    //shifts cloned - (no heading) columns to never be last element in row
    allColumns.each(function (i, o) {
        if (i % divider === 0) {
            if ($('.column-parent:eq(' + i + ')').hasClass("cloned")) {
                let b = i - 2;
                $('.column-parent:eq(' + b + ')').css("margin-right", 50);
            }
        }
    });

}
function splitLargeColumns() {
    let fixedHeight = 700; //SPECIFY THE HEIGHT -> IF THIS IS EXCEDED THE ELEMENT EXCEDING THIS THING IS SHIFTED TO NEXT COLUMN

    column.each(function (i, o) {
        let current = $(o);
        let parent = current.parent('.column-parent');
        if (current.outerHeight() > fixedHeight) {
            let clone = parent.clone();
            let cloneHeading = clone.find('.column-heading');
            let padding = parent.find('.column-heading').outerHeight(true);
            let innerLine = $(o).children('.inner-line');
            let dynamic = 0;
            let indexToDelete = [];
            let totalInnies = current.find('.inner-line').length;
            clone.insertAfter(parent);
            cloneHeading.css("display", "none");
            clone.css('padding-top', padding);
            clone.addClass('cloned');
            indexToDelete = [];

            innerLine.each(function (u, h) {

                dynamic += $(h).outerHeight(true);
                if (dynamic > fixedHeight) {
                    indexToDelete.push(u);

                }
            });

            for (var o = 0; o <= indexToDelete[0] - 1; o++) {
                clone.find('.inner-line:eq(' + o + ')').css('display', 'none');

            }
            for (var t = totalInnies - 1; t > indexToDelete[0] - 1; t--) {
                current.children('.inner-line:eq(' + t + ')').css('display', 'none');
            }

        }
    });
    column = $('.column');
    column.each(function (i, l) {
        let totalHeight = 0;
        let innerLines = $(l).find('.inner-line:visible');
        innerLines.each(function (g, b) {
            totalHeight += $(b).outerHeight(true);
        });
        let columnHeight = totalHeight;//$(l).outerHeight(true);
        let lastCell = $(l).find('.cell:visible').last();
        let lastInnerLine = $(l).find('.inner-line:visible').last();

        let lastElHeight = lastCell.outerHeight(true);

        if ($(l).find('.cell:visible').length === 1) {
            finalHeight = lastElHeight / 2 + 12;
        }
        if (lastInnerLine.children('.column2:visible').length > 0) {
            let lastInnerLineHeight = lastInnerLine.find('.column2:visible').outerHeight(true);
            finalHeight = (columnHeight - lastInnerLineHeight - lastElHeight / 2);
        }
        else {
            finalHeight = (columnHeight - lastElHeight / 2);
        }
        let line = $('.line-column:eq(' + i + ')');
       
        line.css("height", finalHeight);
        console.log(finalHeight);
    });

}


$(document).ready(function () {
    let color;
    calculateLayout();
    addHorizontalLines();
    addVerticalLines();
    splitLargeColumns();
    shiftClonedIfLast();
    PostImage();

    $(".print-png").click(function () {
        html2canvas($('#canvas')[0], {
            scale: 2
        }).then(function (canvas) {
            var a = document.createElement('a');
            a.href = canvas.toDataURL("image/png");
            a.download = 'bubliny.png';
            a.click();
        });
    }); 
    $(".color-picker").click(function () {
    let changerObjects = $('.color-change');
        color = $(this).data('color');
        changerObjects.each(function (i, v) {
            $(v).css("border-color", color);
        });
        $('.column-heading').css("background-color", color);
        PostImage();

    });
    $(".correction-button-plus").click(function () {
        let px = $('#px-correction').val() - 1;
        let lineCorr = $('.line-column:eq(' + px + ')');
        let height = lineCorr.outerHeight(true);
        lineCorr.css("height", height + 1);

    });

    $(".correction-button-").click(function () {
        let px = $('#px-correction').val() - 1;
        let lineCorr = $('.line-column:eq(' + px + ')');
        let height = lineCorr.outerHeight(true);
        lineCorr.css("height", height - 1);
    });
    $(".fulscreen-toggle").click(function () {
        $(this).css("visibility", "hidden");
        document.documentElement.webkitRequestFullScreen();
    });

});

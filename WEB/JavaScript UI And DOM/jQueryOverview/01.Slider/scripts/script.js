/// <reference path="../../Scripts/jquery-2.1.1.js" />

// There are few bugs that I coudn't solve, but overall it works fine. If you enter manual mode it will block the automatic change. Once in manual mode, forever in manual mode (forever = until refresh :D).

$(function () {
    var $sliderContainer = $('#slider-container');
    var $slides = $sliderContainer.find('.slide');
    var $firstSlide = $($slides.first());
    var $lastSlide = $($slides.last());
    var $currentSlide = $firstSlide;
    var $previousButton = $('#previous');
    var $nextButton = $('#next');
    var inManualMode = false;

    $previousButton.on('click', function () {
        inManualMode = true;
        changeSlide(true);
    });

    $nextButton.on('click', function () {
        inManualMode = true;
        changeSlide();
    });

    $currentSlide.fadeIn(1000, function () {
        setTimeout(changeSlide, 5000);
    });

    function changeSlide(changeToPreviuos) {
        $currentSlide.fadeOut(1000, function () {
            // This line fix some of the bugs. I know it's hack but I didn't find better way.
            $slides.hide();

            if (changeToPreviuos) {
                $currentSlide = $currentSlide.prev();

                // Check if we are before the first child.
                if (!$currentSlide[0]) {
                    $currentSlide = $lastSlide;
                }
            }
            else {
                $currentSlide = $currentSlide.next();

                // Check if we are after the last child.
                if (!$currentSlide[0]) {
                    $currentSlide = $firstSlide;
                }
            }

            $currentSlide.fadeIn(1000, function () {
                if (!inManualMode) {
                    setTimeout(changeSlide, 5000);
                }
            })
        });
    }
});
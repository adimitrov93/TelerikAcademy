/// <reference path="libs/underscore-min.js" />
/// <reference path="libs/jquery-2.1.1.min.js" />

$(function () {
    var LENGTH_OF_NUMBER = 4;

    var getRandomNumber = function () {
        var getRandomIntNumber = function (min, max) {
            return Math.floor(Math.random() * (max - min) + min);
        };

        var appendDigit = function (digit) {
            result += digit;
            usedDigits.push(digit);
        };

        var result = '';
        var usedDigits = [];

        for (var i = 0; i < LENGTH_OF_NUMBER; i++) {
            do {
                randomDigit = getRandomIntNumber(1, 10);
            }
            while (_.any(usedDigits, function (item) { return item === randomDigit; }));

            appendDigit(randomDigit);
        }

        return result;
    };

    var getSheepsAndRamsCount = function (computerNumber, userNumber) {
        var result = {
            sheeps: 0,
            rams: 0
        };

        for (var i = 0; i < LENGTH_OF_NUMBER; i++) {
            var currentComputerDigit = computerNumber[i];

            for (var j = 0; j < LENGTH_OF_NUMBER; j++) {
                var currentUserDigit = userNumber[j];

                if (currentComputerDigit === currentUserDigit) {
                    if (i === j) {
                        result.rams++;
                    }
                    else {
                        result.sheeps++;
                    }
                }
            }
        }

        return result;
    };

    var showHighScores = function () {
        var appendLine = function (toAdd) {
            $docFragment.append(toAdd.clone(true));
            $docFragment.append($brElement.clone(true));
        };

        var $container = $('#high-scores-container');
        var scores = JSON.parse(localStorage.getItem('highScores'));
        var $docFragment = $(document.createDocumentFragment());
        var $spanElement = $('<span />');
        var $brElement = $('<br />');

        $spanElement.text('Top scores:');
        appendLine($spanElement);

        if (scores) {
            for (var i = 0, len = scores.length; i < len; i++) {
                $spanElement.text(scores[i].nickname + ': ' + scores[i].score);
                appendLine($spanElement);
            }
        }

        $container.prepend($docFragment);
    };

    var isValidNumber = function (number) {
        if (number.length !== LENGTH_OF_NUMBER) {
            return false;
        }

        for (var i = 0; i < LENGTH_OF_NUMBER; i++) {
            for (var j = i + 1; j < LENGTH_OF_NUMBER; j++) {
                if (number[i] === number[j]) {
                    return false;
                }

                if (number[i] === '0') {
                    return false;
                }
            }
        }

        return true;
    };

    var onUserInputChange = function () {
        var $userInput = $('#user-input');
        var userNumber = $userInput.val();
        $userInput.val('');
        if (isValidNumber(userNumber)) {
            var sheepsAndRamsCount = getSheepsAndRamsCount(computerNumber, userNumber);

            if (sheepsAndRamsCount.rams === 4) {
                $display.text('Congratulations, you won!');

                var nickname = prompt('Enter your nickname:');
                var results = JSON.parse(localStorage.getItem('highScores')) || [];

                var currentScore = 100 - (numberOfGuesses * 2);

                if (_.any(results, function (item) { return item.nickname === nickname; })) {
                    for (var i = 0, len = results.length; i < len; i++) {
                        if (results[i].nickname === nickname) {
                            if (results[i].score < currentScore) {
                                results[i].score = currentScore;
                            }
                        }
                    }
                }
                else {
                    results.push({
                        nickname: nickname,
                        score: currentScore
                    });
                }

                var sortedResults = results.sort(function (first, second) {
                    return second.score - first.score;
                })

                localStorage.setItem('highScores', JSON.stringify(sortedResults));

                // Refresh the web page.
                location.reload();
            }
            else {
                $display.append(userNumber + ' -> Sheeps: ' + sheepsAndRamsCount.sheeps + ' Rams: ' + sheepsAndRamsCount.rams + '<br>');
            }

            numberOfGuesses++;
        }
        else {
            alert('Invalid number. Number must be ' + LENGTH_OF_NUMBER + ' characters long without repeating digits. Number cannot contain 0.')
        }
    };

    var onNewGameBtnClick = function () {
        location.reload();
    };

    var onSurrenderBtnClick = function () {
        alert("Computer's number was " + computerNumber);
        location.reload();
    };

    var onResetBtnClick = function () {
        localStorage.removeItem('highScores');
        location.reload();
    };
    
    var computerNumber = getRandomNumber();
    var $display = $('#current-game-info-container');
    var numberOfGuesses = 0;

    showHighScores();

    $('#user-input').on('change', onUserInputChange);
    $('#new-game-btn').on('click', onNewGameBtnClick);
    $('#surrender-btn').on('click', onSurrenderBtnClick);
    $('#reset-btn').on('click', onResetBtnClick);
});
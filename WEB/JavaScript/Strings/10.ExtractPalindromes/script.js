function onButtonClick() {
    var text = document.getElementById("input-field").value,
        palindromes = extractPalindromes(text);

    for (var i = 0; i < palindromes.length; i++) {
        jsConsole.writeLine(palindromes[i]);
    }
}

function extractPalindromes(text) {
    var splitRegex = /[.!?,:;"'()\s]/,
        palindromes = [],
        words = removeEmpties(text.split(splitRegex));

    for (var i = 0; i < words.length; i++) {
        if (isPalindrome(words[i])) {
            palindromes.push(words[i]);
        }
    }

    return palindromes;
}

function removeEmpties(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] === "") {
            arr.splice(i, 1);
        }
    }

    return arr;
}

function isPalindrome(str) {
    var isPalindrome = true;

    str = str.toLowerCase();

    for (var i = 0; i < str.length / 2; i++) {
        if (str[i] !== str[str.length - i - 1]) {
            isPalindrome = false;
            break;
        }
    }

    return isPalindrome;
}
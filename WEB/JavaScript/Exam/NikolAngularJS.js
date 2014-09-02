﻿function Solve(args) {
    var defVarsLen = parseInt(args[0]);
    var variables = getVars(args, defVarsLen);

    function getVars(args, defVarsLen) {
        var array = args.slice(1, defVarsLen + 1);
        var vars = {};

        for (var i = 0; i < array.length; i++) {
            var currentLine = array[i];
            var inName = true;
            var inValue = false;
            var inArray = false;
            var currentName = '';
            var currentValue = '';
            var currentArray = [];

            for (var j = 0; j < currentLine.length; j++) {
                var currentSymbol = currentLine[j];

                if (currentSymbol === '-') {
                    inName = false;
                    inValue = true;

                    continue;
                }

                if (currentSymbol === ';') {
                    inArray = true;

                    if (isNumber(currentValue)) {
                        currentArray.push(parseInt(currentValue));
                    }
                    else {
                        currentArray.push(currentValue);
                    }

                    currentValue = '';

                    continue;
                }

                if (inName) {
                    currentName += currentSymbol;

                    continue;
                }

                if (inValue) {
                    currentValue += currentSymbol;
                }

                if (currentSymbol === '\n' || currentSymbol === '\r') {
                    if (inArray) {
                        if (isNumber(currentValue)) {
                            currentArray.push(parseInt(currentValue));
                        }
                        else {
                            currentArray.push(currentValue);
                        }
                    }

                    break;
                }
            }

            //console.log(currentName);
            //console.log(currentValue);
            //console.log(currentArray);

            if (inArray) {
                vars[currentName] = currentArray;
            }
            else {
                if (currentValue === 'false') {
                    currentValue = false;
                }
                else if (currentValue === 'true') {
                    currentValue = true;
                }

                vars[currentName] = currentValue;
            }
        }

        return vars;
    }

    function isNumber(str) {
        return str == Number(str);
    }

    for (var i = 0; i < args.length; i++) {
        while (args[i].indexOf('nk-model') != -1) {
            var modelIndex = args[i].indexOf('nk-model');
            var startIndex = args[i].indexOf('>', modelIndex);
            var endIndex = args[i].indexOf('<', startIndex);
            var name = args[i].substring(startIndex, endIndex);

            console.log(name);
        }
    }
}

var testDefineTemplate = [
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '    <ul id="menu">',
    '        <li>Home</li>',
    '        <li>About us</li>',
    '    </ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '    <footer>',
    '        Copyright Telerik Academy 2014',
    '    </footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    <nk-template render="menu" />',
    '',
    '    <h1><nk-model>title</nk-model></h1>',
    '    <nk-if condition="showSubtitle">',
    '        <h2><nk-model>subTitle</nk-model></h2>',
    '        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '    </nk-if>',
    '',
    '    <ul>',
    '        <nk-repeat for="student in students">',
    '            <li>',
    '                <nk-model>student</nk-model>',
    '            </li>',
    '            <li>Multiline <nk-model>title</nk-model></li>',
    '        </nk-repeat>',
    '    </ul>',
    '    <nk-if condition="showMarks">',
    '        <div>',
    '            <nk-model>marks</nk-model> ',
    '        </div>',
    '    </nk-if>',
    '',
    '    <nk-template render="footer" />',
    '</body>',
    '</html>'
];

console.log(Solve(testDefineTemplate));
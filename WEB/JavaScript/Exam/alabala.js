//var inNkState = false;
//var inTemplateDef = false;
//var currentTemplateName = '';
//var currentTemplateValue = '';
//var inName = false;
//var inValue = false;

//for (var i = defVarsLen + 2; i < args.length; i++) {
//    var currentLine = args[i];

//    for (var j = 0; j < currentLine.length; j++) {
//        var currentSymbol = currentLine[j];

//        if (currentSymbol === '<') {
//            if (currentLine.substr((j + 1), 3) === 'nk-') {
//                inNkState = true;
//                j += 3;
//            }
//            else if (currentLine.substr((j + 1), 4) === '/nk-') {
//                inNkState = false;
//                j = currentLine.indexOf('>', j + 4);

//                if (inTemplateDef) {
//                    templates[currentTemplateName] = currentTemplateValue;
//                    inTemplateDef = false;
//                }
//            }

//            if (inValue) {
//                currentTemplateValue += currentSymbol;
//            }

//            continue;
//        }

//        if (inTemplateDef) {
//            if (currentSymbol === '"') {
//                if (!inName && !inValue) {
//                    inName = true;
//                }
//                else {
//                    inName = false;
//                }

//                continue;
//            }

//            if (currentSymbol === '>') {
//                if (!inValue) {
//                    inValue = true;
//                }
//                else {
//                    currentTemplateValue += currentSymbol;
//                }

//                continue;
//            }

//            if (inName) {
//                currentTemplateName += currentSymbol;
//            }

//            if (inValue) {
//                currentTemplateValue += currentSymbol;
//            }

//            continue;
//        }

//        if (inNkState) {
//            if (currentLine.substr(j, 8) === 'template') {
//                inTemplateDef = true;
//                j += 8;
//            }

//            continue;
//        }
//    }
//}
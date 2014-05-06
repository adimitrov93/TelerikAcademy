function convertToText() {
    var number = parseInt(document.getElementById("input").value),
        result = "",
        temp;

    while (isNaN(number)) {
        jsConsole.writeLine("Incorrect input!");
        return;
    }

    if (number < 100)
    {
        if (number < 20)
        {
            switch (number)
            {
                case 0:
                    result += "Zero";
                    break;
                case 1:
                    result += "One";
                    break;
                case 2:
                    result += "Two";
                    break;
                case 3:
                    result += "Three";
                    break;
                case 4:
                    result += "Four";
                    break;
                case 5:
                    result += "Five";
                    break;
                case 6:
                    result += "Six";
                    break;
                case 7:
                    result += "Seven";
                    break;
                case 8:
                    result += "Eight";
                    break;
                case 9:
                    result += "Nine";
                    break;
                case 10:
                    result += "Ten";
                    break;
                case 11:
                    result += "Eleven";
                    break;
                case 12:
                    result += "Twelve";
                    break;
                case 13:
                    result += "Thirteen";
                    break;
                case 14:
                    result += "Fourteen";
                    break;
                case 15:
                    result += "Fifteen";
                    break;
                case 16:
                    result += "Sixteen";
                    break;
                case 17:
                    result += "Seventeen";
                    break;
                case 18:
                    result += "Eighteen";
                    break;
                case 19:
                    result += "Nineteen";
                    break;
                default:
                    jsConsole.writeLine("Error occured!");
                    return;
            }
        }
        else
        {
            temp = number / 10;
            temp = parseInt(temp);

            switch (temp)
            {
                case 2:
                    result += "Twenty";
                    break;
                case 3:
                    result += "Thirty";
                    break;
                case 4:
                    result += "Forty";
                    break;
                case 5:
                    result += "Fifty";
                    break;
                case 6:
                    result += "Sixty";
                    break;
                case 7:
                    result += "Seventy";
                    break;
                case 8:
                    result += "Eighty";
                    break;
                case 9:
                    result += "Ninety";
                    break;
                default:
                    jsConsole.writeLine("Error occured!");
                    return;
            }

            temp = number % 10;

            switch (temp)
            {
                case 0:
                    break;
                case 1:
                    result += " one";
                    break;
                case 2:
                    result += " two";
                    break;
                case 3:
                    result += " three";
                    break;
                case 4:
                    result += " four";
                    break;
                case 5:
                    result += " five";
                    break;
                case 6:
                    result += " six";
                    break;
                case 7:
                    result += " seven";
                    break;
                case 8:
                    result += " eight";
                    break;
                case 9:
                    result += " nine";
                    break;
                default:
                    jsConsole.writeLine("Error occured!");
                    return;
            }
        }
    }
    else
    {
        temp = number / 100;
        temp = parseInt(temp);

        switch (temp)
        {
            case 1:
                result += "A hundred";
                break;
            case 2:
                result += "Two hundred";
                break;
            case 3:
                result += "Three hundred";
                break;
            case 4:
                result += "Four hundred";
                break;
            case 5:
                result += "Five hundred";
                break;
            case 6:
                result += "Six hundred";
                break;
            case 7:
                result += "Seven hundred";
                break;
            case 8:
                result += "Eight hundred";
                break;
            case 9:
                result += "Nine hundred";
                break;
            default:
                jsConsole.writeLine("Error occured!");
                return;
        }

        temp = number / 10;
        temp = parseInt(temp);
        temp %= 10;

        if (temp < 2)
        {
            temp = number % 100;
            switch (temp)
            {
                case 0:
                    break;
                case 1:
                    result += " and one";
                    break;
                case 2:
                    result += " and two";
                    break;
                case 3:
                    result += " and three";
                    break;
                case 4:
                    result += " and four";
                    break;
                case 5:
                    result += " and five";
                    break;
                case 6:
                    result += " and six";
                    break;
                case 7:
                    result += " and seven";
                    break;
                case 8:
                    result += " and eight";
                    break;
                case 9:
                    result += " and nine";
                    break;
                case 10:
                    result += " and ten";
                    break;
                case 11:
                    result += " and eleven";
                    break;
                case 12:
                    result += " and twelve";
                    break;
                case 13:
                    result += " and thirteen";
                    break;
                case 14:
                    result += " and fourteen";
                    break;
                case 15:
                    result += " and fifteen";
                    break;
                case 16:
                    result += " and sixteen";
                    break;
                case 17:
                    result += " and seventeen";
                    break;
                case 18:
                    result += " and eighteen";
                    break;
                case 19:
                    result += " and nineteen";
                    break;
                default:
                    jsConsole.writeLine("Error occured!");
                    return;
            }
        }
        else
        {
            if (number % 10 === 0)
            {
                switch (temp)
                {
                    case 2:
                        result += " and twenty";
                        break;
                    case 3:
                        result += " and thirty";
                        break;
                    case 4:
                        result += " and forty";
                        break;
                    case 5:
                        result += " and fifty";
                        break;
                    case 6:
                        result += " and sixty";
                        break;
                    case 7:
                        result += " and seventy";
                        break;
                    case 8:
                        result += " and eighty";
                        break;
                    case 9:
                        result += " and ninety";
                        break;
                    default:
                        jsConsole.writeLine("Error occured!");
                        return;
                }
            }
            else
            {
                switch (temp)
                {
                    case 2:
                        result += " and twenty";
                        break;
                    case 3:
                        result += " and thirty";
                        break;
                    case 4:
                        result += " and forty";
                        break;
                    case 5:
                        result += " and fifty";
                        break;
                    case 6:
                        result += " and sixty";
                        break;
                    case 7:
                        result += " and seventy";
                        break;
                    case 8:
                        result += " and eighty";
                        break;
                    case 9:
                        result += " and ninety";
                        break;
                    default:
                        jsConsole.writeLine("Error occured!");
                        return;
                }

                temp = number % 10;

                switch (temp)
                {
                    case 0:
                        break;
                    case 1:
                        result += " one";
                        break;
                    case 2:
                        result += " two";
                        break;
                    case 3:
                        result += " three";
                        break;
                    case 4:
                        result += " four";
                        break;
                    case 5:
                        result += " five";
                        break;
                    case 6:
                        result += " six";
                        break;              
                    case 7:
                        result += " seven";
                        break;
                    case 8:                 
                        result += " eight";
                        break;
                    case 9:
                        result += " nine";
                        break;
                    default:
                        jsConsole.writeLine("Error occured!");
                        return;
                }
            }
        }
    }

    jsConsole.writeLine(result);
}
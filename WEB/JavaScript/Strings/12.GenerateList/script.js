function onLoad() {
    var template = document.getElementById("template").innerHTML.trim(),
        people = [
            {
                name: "Pesho Goshov",
                age: 21
            },
            {
                name: "Gosho Peshov",
                age: 22
            }
        ],
        list = generateList(people, template);

    document.body.appendChild(list);
}

// This function will work with every valid template (the div in the .html file).
function generateList(data, template) {
    var ul = document.createElement("ul"),
        li,
        openScope = 0,
        closeScope = 0,
        currentProperty,
        plainTextStartIndex = 0,
        plainTextEndIndex = 0;

    for (var i = 0; i < data.length; i++) {
        li = document.createElement("li");
        closeScope = 0;
        plainTextStartIndex = 0;
        openScope = template.indexOf("-{", closeScope);
        plainTextEndIndex = openScope,
        numberOfChilds = 0;

        while (openScope !== -1) {
            closeScope = template.indexOf("}-", openScope);
            currentProperty = template.substring(openScope + 2, closeScope);
            li.innerHTML += template.substring(plainTextStartIndex, plainTextEndIndex);

            if (li.childElementCount > numberOfChilds) {
                li.childNodes[li.childNodes.length - 1].innerHTML += data[i][currentProperty];
                plainTextStartIndex = template.indexOf(">", plainTextEndIndex) + 1;
                numberOfChilds++;
            } else {
                li.innerHTML += data[i][currentProperty];
                plainTextStartIndex = closeScope + 2;
            }

            openScope = template.indexOf("-{", closeScope);
            plainTextEndIndex = openScope;
        }

        li.innerHTML += template.substring(plainTextStartIndex, template.length);
        ul.appendChild(li);
    }

    return ul;
}
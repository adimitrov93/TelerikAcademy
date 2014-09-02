window.onload = function () {
    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];
    var tagCloud = generateTagCloud(tags, 17, 42);

    function generateTagCloud(tags, minSize, maxSize) {
        var counts = countTags(tags);
        var sortedTags = sortTags(counts);
        var actualTagsCount = countActualTags(sortedTags);
        var fontSizeStep = (maxSize - minSize) / (actualTagsCount - 1);
        var currentFontSize = minSize;
        var container = generateContainer();

        generateTags(container, sortedTags, currentFontSize, fontSizeStep);

        console.log(container.innerHTML);
        document.body.appendChild(container);

        function countTags(tags) {
            var counts = {};

            for (var i = 0, length = tags.length; i < length; i++) {
                var currentTag = tags[i].toLowerCase();

                if (counts[currentTag]) {
                    counts[currentTag]++;
                }
                else {
                    counts[currentTag] = 1;
                }
            }

            return counts;
        }

        function sortTags(counts) {
            var result = [];

            for (var tag in counts) {
                var currentTagCount = counts[tag];

                if (result[currentTagCount]) {
                    result[currentTagCount] += (', ' + tag);
                }
                else {
                    result[currentTagCount] = tag;
                }
            }

            return result;
        }

        function countActualTags(sortedTags) {
            var count = 0;

            for (var tag in sortedTags) {
                count++;
            }

            return count;
        }

        function generateContainer() {
            var div = document.createElement('div');

            div.style.border = '1px solid black';
            div.style.padding = '5px';
            div.style.width = '500px';
            div.style.textOverflow

            return div;
        }

        function generateTags(container, sortedTags, currentFontSize, fontSizeStep) {
            var anchor = document.createElement('span');
            anchor.style.verticalAlign = 'baseline';

            var emptySpace = document.createTextNode(' ');

            for (var tagSize in sortedTags) {
                var currentTags = sortedTags[tagSize].split(', ');
                anchor.style.fontSize = currentFontSize + 'px';

                for (var i = 0, length = currentTags.length; i < length; i++) {
                    anchor.innerHTML = currentTags[i];

                    var randomNumber = Math.floor(Math.random() * (container.childNodes.length - 1));

                    if (randomNumber < 0) {
                        container.appendChild(anchor.cloneNode(true));
                        container.appendChild(emptySpace.cloneNode(true));
                    }
                    else if (randomNumber % 2 === 0) {
                        container.insertBefore(anchor.cloneNode(true), container.childNodes[randomNumber]);
                        container.insertBefore(emptySpace.cloneNode(true), container.childNodes[randomNumber + 1]);
                    }
                    else {
                        container.insertBefore(anchor.cloneNode(true), container.childNodes[randomNumber].nextSibling);
                        container.insertBefore(emptySpace.cloneNode(true), container.childNodes[randomNumber + 1].nextSibling);
                    }
                }

                currentFontSize += fontSizeStep;
            }
        }
    }
};
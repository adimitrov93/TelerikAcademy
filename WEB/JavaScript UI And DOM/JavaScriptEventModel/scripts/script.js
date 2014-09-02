(function () {
    document.querySelector('#add-new-item-btn').addEventListener('click', onAddNewItemBtnClick);
    document.querySelector('#hide-btn').addEventListener('click', onHideBtnClick);
    document.querySelector('#show-btn').addEventListener('click', onShowBtnClick);

    function onAddNewItemBtnClick() {
        var description = document.querySelector('#add-new-item-description').value;
        
        if (description === '') {
            alert('Enter description!');

            return;
        }

        var list = document.querySelector('#list-of-items');

        if (!list) {
            list = document.createElement('ul');
            list.id = 'list-of-items';
            document.querySelector('#list-container').appendChild(list);
        }

        var docFragment = document.createDocumentFragment();

        var lastChild = list.childNodes[list.childNodes.length - 1];
        var lastChildId;

        if (lastChild) {
            lastChildId = lastChild.id
        }
        else {
            lastChildId = 'item-0';
        }

        var newItemIdNumber = getLastCharAsNumber(lastChildId) + 1;
        var newItem = document.createElement('li');
        newItem.id = 'item-' + newItemIdNumber;
        newItem.innerHTML += description;

        var removeBtn = document.createElement('button');
        removeBtn.id = 'item-button-' + newItemIdNumber;
        removeBtn.innerHTML = 'Remove';
        removeBtn.style.marginLeft = '50px';
        removeBtn.addEventListener('click', onRemoveBtnClick);

        newItem.appendChild(removeBtn);
        docFragment.appendChild(newItem);
        list.appendChild(docFragment);
    }

    function onRemoveBtnClick(){
        var elementIdToRemove = 'item-' + getLastCharAsNumber(this.id);
        var elementToRemove = document.querySelector('#' + elementIdToRemove);

        elementToRemove.parentNode.removeChild(elementToRemove);
    }

    function getLastCharAsNumber(str) {
        return parseInt(str.substr(str.length - 1));
    }

    function onHideBtnClick() {
        document.querySelector('#list-container').style.display = 'none';
    }

    function onShowBtnClick() {
        document.querySelector('#list-container').style.display = '';
    }
})();
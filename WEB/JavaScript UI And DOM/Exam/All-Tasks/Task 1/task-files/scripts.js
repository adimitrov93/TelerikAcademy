function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var documentFragment = document.createDocumentFragment();

	var preview = document.createElement('div');
	preview.className = 'preview';
	preview.style.display = 'inline-block';
	preview.style.padding = '20px';
	preview.style.verticalAlign = 'top';

	var title = document.createElement('h1');
	title.className = 'title';
	title.style.textAlign = 'center';

	var image = document.createElement('img');
	image.className = 'image';
	image.style.width = '500px';
	image.style.borderRadius = '20px';

	preview.appendChild(title.cloneNode(true));
	preview.appendChild(image.cloneNode(true));

	var thumbnailContainer = document.createElement('div');
	thumbnailContainer.className = 'thumbnail-container';
	thumbnailContainer.style.display = 'inline-block';
	thumbnailContainer.style.height = '500px';
	thumbnailContainer.style.width = '250px';
	thumbnailContainer.style.overflowY = 'scroll';
	thumbnailContainer.style.padding = '20px';
	thumbnailContainer.style.textAlign = 'center';
	thumbnailContainer.style.verticalAlign = 'top';
	thumbnailContainer.style.textAlign = 'center';

	generateThumbnails(thumbnailContainer, items);

	documentFragment.appendChild(preview);
	documentFragment.appendChild(thumbnailContainer);

	container.appendChild(documentFragment);

	thumbnailContainer.addEventListener('click', function(e) {
		if (e.target.className === 'image') {
			preview.querySelector('.title').innerHTML = e.target.previousSibling.innerHTML;
		 	preview.querySelector('.image').setAttribute('src', e.target.getAttribute('src'));
		}
	});

	container.querySelector('.thumbnail .image').click();

	thumbnailContainer.addEventListener('mouseover', function(e) {
		if (e.target.className === 'image') {
			e.target.parentNode.style.backgroundColor = '#59C4FF';
		}
	});

	thumbnailContainer.addEventListener('mouseout', function(e) {
		if (e.target.className === 'image') {
			e.target.parentNode.style.backgroundColor = '';
		}
	});

	container.querySelector('.filter-input').addEventListener('keyup', function() {
		var thumbnails = container.querySelectorAll('.thumbnail');

		if (this.value) {
			for (var i = 0, length = thumbnails.length; i < length; i++) {
				var titleOfCurrentThumbnail = thumbnails[i].querySelector('.title').innerText.toLowerCase();

				if (titleOfCurrentThumbnail.indexOf(this.value) < 0) {
					thumbnails[i].style.display = 'none';
				}
				else {
					thumbnails[i].style.display = '';
				}
			};	
		}
		else {
			for (var i = 0,length = thumbnails.length; i < length; i++) {
				thumbnails[i].style.display = '';
			};
		}
	});

	function generateThumbnails(thumbnailContainer, items) {
		var thumbnail = document.createElement('div');
		thumbnail.className = 'thumbnail';
		thumbnail.style.width = '80%';
		thumbnail.style.padding = '10px';
		thumbnail.style.margin = '0 auto';

		var title = document.createElement('h2');
		title.className = 'title';
		title.style.textAlign = 'center';
		title.style.margin = '0';

		var filterLabel = document.createElement('h4');
		filterLabel.innerHTML = 'Filter';
		filterLabel.style.textAlign = 'center';
		filterLabel.style.margin = '0';

		var input = document.createElement('input');
		input.className = 'filter-input';
		input.style.width = '80%';

		image.style.width = '100%';
		image.style.borderRadius = '10px';

		thumbnailContainer.appendChild(filterLabel);
		thumbnailContainer.appendChild(input);

		for (var i = 0, length = items.length; i < length; i++) {
			var currentItem = items[i];

			title.innerHTML = currentItem.title;
			thumbnail.appendChild(title.cloneNode(true));
			image.setAttribute('src', currentItem.url);
			thumbnail.appendChild(image.cloneNode(true));

			thumbnailContainer.appendChild(thumbnail.cloneNode(true));

			for (var j = 0; j < thumbnail.children.length; ) {
				var child = thumbnail.children[j];
				child.parentNode.removeChild(child);
			}
		};
	}
}
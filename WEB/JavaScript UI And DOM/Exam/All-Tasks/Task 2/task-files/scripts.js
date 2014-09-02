$.fn.gallery = function (numberOfColumns) {
	var numberOfColumns = numberOfColumns || 4;
    var $this = $(this);
    var $gallery = $this;
    var $galleryList = $gallery.find('.gallery-list');
    var $selectedContainer = $gallery.find('.selected');
    var $previousImage = $selectedContainer.find('#previous-image');
	var $currentImage = $selectedContainer.find('#current-image');
	var $nextImage = $selectedContainer.find('#next-image');
	var dataInfos = getDataInfos($gallery);

    $this.addClass('gallery');
    $selectedContainer.hide();

    $galleryList.find(':nth-child(' + numberOfColumns + 'n+1)').addClass('clearfix');

    $galleryList.on('click', '.image-container', function(e) {
    	var $this = $(this);

        var currentImageDataInfo = $this.find('img').data('info');

    	var currentImageIndex = dataInfos.indexOf(currentImageDataInfo);
    	var previousImageIndex = currentImageIndex - 1;
    	var nextImageIndex = currentImageIndex + 1;

		if (previousImageIndex < 0) {
    		previousImageIndex = dataInfos.length - 1;
    	}

    	if (nextImageIndex > dataInfos.length - 1) {
    		nextImageIndex = 0;
    	}

    	var previousImageUrl = 'imgs/' + dataInfos[previousImageIndex] + '.jpg';
    	var currentImageUrl = 'imgs/' + dataInfos[currentImageIndex] + '.jpg';
    	var nextImageUrl = 'imgs/' + dataInfos[nextImageIndex] + '.jpg';

    	$previousImage.attr('src', previousImageUrl);
    	$currentImage.attr('src', currentImageUrl);
    	$nextImage.attr('src', nextImageUrl);

        $galleryList.addClass('blurred');
    	$galleryList.prepend($('<div>').addClass('disabled-background'));
        $selectedContainer.show();

    	$previousImage.on('click', function() {
    		nextImageIndex = currentImageIndex;
    		currentImageIndex = previousImageIndex;
    		previousImageIndex -= 1;

    		if (previousImageIndex < 0) {
	    		previousImageIndex = dataInfos.length - 1;
	    	}

    		previousImageUrl = 'imgs/' + dataInfos[previousImageIndex] + '.jpg';
            currentImageUrl = 'imgs/' + dataInfos[currentImageIndex] + '.jpg';
            nextImageUrl = 'imgs/' + dataInfos[nextImageIndex] + '.jpg';

	    	$previousImage.attr('src', previousImageUrl);
	    	$currentImage.attr('src', currentImageUrl);
	    	$nextImage.attr('src', nextImageUrl);
    	});

    	$nextImage.on('click', function() {
    		previousImageIndex = currentImageIndex;
    		currentImageIndex = nextImageIndex;
    		nextImageIndex += 1;

    		if (nextImageIndex > dataInfos.length - 1) {
	    		nextImageIndex = 0;
	    	}

    		previousImageUrl = 'imgs/' + dataInfos[previousImageIndex] + '.jpg';
	    	currentImageUrl = 'imgs/' + dataInfos[currentImageIndex] + '.jpg';
	    	nextImageUrl = 'imgs/' + dataInfos[nextImageIndex] + '.jpg';

	    	$previousImage.attr('src', previousImageUrl);
	    	$currentImage.attr('src', currentImageUrl);
	    	$nextImage.attr('src', nextImageUrl);
    	});

    	$currentImage.on('click', function() {
    		$selectedContainer.hide();
	    	$gallery.find('.disabled-background').remove();
	    	$galleryList.removeClass('blurred');

	    	$previousImage.off();
	    	$currentImage.off();
	    	$nextImage.off();
    	})
    });

	function getDataInfos ($gallery) {
		var imgs = $gallery.find('.gallery-list').find('img');
		var result = [];

		for (var i = 0, length = imgs.length; i < length; i++) {
			var $currentImg = $(imgs[i]);

			result.push($currentImg.data('info'));
		}

		return result;
	}
};
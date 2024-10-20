export function imgDragAndDrop(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    let mouseX, mouseY, imgX, imgY;
    let isDragging = false;

    // windows 端鼠标控制
    //function handleMouseDown(event) {
    //    mouseX = event.clientX;
    //    mouseY = event.clientY;
    //    imgX = element.offsetLeft;
    //    imgY = element.offsetTop;
    //    isDragging = true;

    //    element.style.cursor = 'grabbing';

    //    document.addEventListener('mousemove', handleMouseMove);
    //    document.addEventListener('mouseup', handleMouseUp);
    //}

    //function handleMouseMove(event) {
    //    if (isDragging) {
    //        const deltaX = event.clientX - mouseX;
    //        const deltaY = event.clientY - mouseY;

    //        element.style.left = imgX + deltaX + 'px';
    //        element.style.top = imgY + deltaY + 'px';
    //    }
    //}

    //function handleMouseUp() {
    //    if (isDragging) {
    //        isDragging = false;
    //        element.style.cursor = 'grab';

    //        document.removeEventListener('mousemove', handleMouseMove);
    //        document.removeEventListener('mouseup', handleMouseUp);
    //    }
    //}

    //element.addEventListener('mousedown', handleMouseDown);

    //element.addEventListener('dragstart', function (event) {
    //    event.preventDefault();
    //});

    //// Handle mouse leaving window
    //window.addEventListener('mouseout', function (event) {
    //    if (event.target === document.body || event.target === document.documentElement) {
    //        handleMouseUp();
    //    }
    //});

    function handleTouchDown(event) {
        mouseX = event.changedTouches[0].clientX;
        mouseY = event.changedTouches[0].clientY;
        imgX = element.offsetLeft;
        imgY = element.offsetTop;
        isDragging = true;

        element.style.cursor = 'grabbing';

        document.addEventListener('touchmove', handleTouchMove);
        document.addEventListener('touchend', handleTouchUp);
    }

    function handleTouchMove(event) {
        if (isDragging) {
            const deltaX = event.targetTouches[0].clientX - mouseX;
            const deltaY = event.targetTouches[0].clientY - mouseY;

            element.style.left = imgX + deltaX + 'px';
            element.style.top = imgY + deltaY + 'px';
        }
    }

    function handleTouchUp() {
        if (isDragging) {
            isDragging = false;
            element.style.cursor = 'grab';

            document.removeEventListener('touchmove', handleTouchMove);
            document.removeEventListener('touchend', handleTouchUp);
        }
    }

    element.addEventListener('touchstart', handleTouchDown);

    element.addEventListener('dragstart', function (event) {
        event.preventDefault();
    });
}

export function getStyle(element, styleProp) {
    if (element.currentStyle)
        return element.currentStyle[styleProp];
    else if (window.getComputedStyle)
        return document.defaultView.getComputedStyle(element, null).getPropertyValue(styleProp);
}
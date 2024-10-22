

export function imgDragAndDrop(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    let mouseX, mouseY, imgX, imgY;
    let isDragging = false;
    let currentDistance = 0

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




    //function handleTouchStart(event) {
    //    event.preventDefault();
    //    const touches = event.touches
    //    mouseX = event.changedTouches[0].clientX;
    //    mouseY = event.changedTouches[0].clientY;
    //    imgX = element.offsetLeft;
    //    imgY = element.offsetTop;

    //    isDragging = true;

    //    document.addEventListener('touchmove', handleTouchMove);
    //    document.addEventListener('touchend', handleTouchEnd);
    //}

    //function handleTouchMove(event) {

    //    const events = event.targetTouches[0];
    //    if (isDragging) {
    //        const deltaX = events.clientX - mouseX;
    //        const deltaY = events.clientY - mouseY;

    //        element.style.left = imgX + deltaX + 'px';
    //        element.style.top = imgY + deltaY + 'px';
    //    }

    //}

    //function handleTouchEnd() {
    //    if (isDragging) {
    //        isDragging = false;
    //    }

    //    document.removeEventListener('touchmove', handleTouchMove);
    //    document.removeEventListener('touchend', handleTouchEnd);
    //}

    //element.addEventListener('touchstart', handleTouchStart);

    element.pinchZoom = new PinchZoom.default(element, {
        minZoom: 1,
        maxZoom: 4,
        useMouseWheel: true
    })
}

export function destroy(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    element.pinchZoom.destroy();
}

export function getStyle(element, styleProp) {
    if (element.currentStyle)
        return element.currentStyle[styleProp];
    else if (window.getComputedStyle)
        return document.defaultView.getComputedStyle(element, null).getPropertyValue(styleProp);
}
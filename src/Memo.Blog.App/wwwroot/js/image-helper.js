

export function imgDragAndDrop(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    element.panzoom =  panzoom(element, {
        maxZoom: 6,
        minZoom: 1
    });
}

export function reset(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    element.panzoom.zoomAbs(0, 0, 1);
    element.panzoom.moveTo(0, 0);
}

export function getStyle(element, styleProp) {
    if (element.currentStyle)
        return element.currentStyle[styleProp];
    else if (window.getComputedStyle)
        return document.defaultView.getComputedStyle(element, null).getPropertyValue(styleProp);
}
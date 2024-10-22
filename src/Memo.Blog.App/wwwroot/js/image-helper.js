export function initPanZoom(element) {
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
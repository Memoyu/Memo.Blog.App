export function initPanZoom(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    try {
        const panzoom = Panzoom(element, {
            minScale: 1,
            maxScale: 5,
        });

        panzoom.zoom(1, { animate: true })

        element.parentElement.addEventListener('wheel', function (event) {
            panzoom.zoomWithWheel(event)
        })

        element.panzoom = panzoom;

    } catch (e) {
        console.log(e);
    }
}

export function reset(element) {
    if (!element) {
        throw new Error('Element not found.');
    }

    element.panzoom.reset();
}
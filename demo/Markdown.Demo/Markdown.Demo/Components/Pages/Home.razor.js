var reactDOM;

export function mdrender(text) {
    reactDOM = ReactDOM.createRoot(document.getElementById('marked-content'));
    const mddom = React.createElement(MdEditorRT.MdPreview, {
        modelValue: text
    })

    console.log(mddom)
    reactDOM.render(mddom);
}
export function unmount() {
    reactDOM?.unmount();
}
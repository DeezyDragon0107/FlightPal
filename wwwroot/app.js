export function getSelectedText() {
    let text = "";
    const post = document.getElementById('post-area')
    if (window.getSelection) {
        text = window.getSelection().toString();
    }
    return text;
}

export function getText() {
    let text = "";
    const post = document.getElementById('post-area')
    text = post.innerHTML;
    return text;
}

export function comText(command) {
    document.execCommand(command, false, null)
}

export function setText(text) {
    const post = document.getElementById('post-area')
    post.innerHTML = text;
}

export function clearFileInput() {
    const fileInput = document.getElementById('inputFile');
    fileInput.value = '';
}
 
function OpenModal() {
    const modalButton = document.querySelector(".btn-modal");

    if (modalButton !== undefined){
        modalButton.dispatchEvent(new Event('click'));
    }
}
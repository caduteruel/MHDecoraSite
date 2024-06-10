const filterSelect = document.getElementById("filter-select");
const filterableCards = document.querySelectorAll(".filterable-cards .card");

const filterCards = e => {
    let filteredCards = Array.from(filterableCards);
    const selectedOption = e.target.options[e.target.selectedIndex];

    if (selectedOption.dataset.name === "order") {
        filteredCards.sort((a, b) => {
            const titleA = a.querySelector(".card-title").textContent.trim();
            const titleB = b.querySelector(".card-title").textContent.trim();
            return titleA.localeCompare(titleB);
        });
    } else if (selectedOption.dataset.name === "recent") {
        filteredCards.sort((a, b) => {
            const dateA = new Date(a.dataset.recentDate);
            const dateB = new Date(b.dataset.recentDate);
            return dateB - dateA;
        });
    } 

    const cardsContainer = document.querySelector(".filterable-cards");
    cardsContainer.innerHTML = "";
    filteredCards.forEach(card => {
        card.classList.remove("hide");
        cardsContainer.appendChild(card);
    });
};

filterSelect.addEventListener("change", filterCards);

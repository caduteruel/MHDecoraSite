const menuButton = document.getElementById("menu");
const navItems = document.querySelector(".nav-items");
const navLinks = document.querySelectorAll(".nav-links a");

menuButton.onclick = () => {
    navItems.classList.toggle("active");
};

navLinks.forEach(link => {
    link.addEventListener("click", () => {
        navItems.classList.remove("active");
    });
});


let currentIndex = 0;
const slides = document.querySelectorAll(".slider-box");
const totalSlides = slides.length;

function showSlide(index) {
  slides.forEach((slide, i) => {
    slide.classList.remove("active", "previous", "show");
    if (i === index) {
      slide.classList.add("show");
      setTimeout(() => slide.classList.add("active"), 20);
    } else if (i === (index - 1 + totalSlides) % totalSlides) {
      slide.classList.add("previous");
      setTimeout(() => slide.classList.remove("show"), 1000);
    }
  });
}

function nextSlide() {
  currentIndex = (currentIndex + 1) % totalSlides;
  showSlide(currentIndex);
}

setInterval(nextSlide, 60000);

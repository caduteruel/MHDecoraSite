document.querySelectorAll('.product-img-holder').forEach(holder => {
    holder.addEventListener('click', () => {
        document.querySelector('.product-img-holder.active').classList.remove('active');
        holder.classList.add('active');
    });
});
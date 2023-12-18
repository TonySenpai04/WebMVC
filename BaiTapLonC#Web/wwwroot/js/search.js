
function searchProducts() {
    // Lấy giá trị từ ô nhập liệu
    var searchInput = document.getElementById('searchInput').value.toLowerCase();

    // Lấy danh sách tất cả các sản phẩm
    var productsMen = document.querySelectorAll('.item');
    var productsWomen = document.querySelectorAll('.item');
    var productsKid = document.querySelectorAll('.item');

    // Gộp tất cả sản phẩm vào một mảng
    var products = [...productsMen, ...productsWomen, ...productsKid];
    // var products = document.querySelectorAll('.men-item-carousel .item');

    // Lặp qua từng sản phẩm để kiểm tra và ẩn/hiện dựa trên từ khóa tìm kiếm
    products.forEach(function (product) {
        var productName = product.querySelector('.down-content h4').innerText.toLowerCase();
        console.log(productName);
        if (productName.includes(searchInput)) {
            // Nếu tên sản phẩm chứa từ khóa tìm kiếm, hiển thị sản phẩm
            product.style.display = 'block';
            console.log(product.style.display);
        } else {
            // Ngược lại, ẩn sản phẩm
            product.style.display = 'none';
            console.log(product.style.display);
        }
    });

}

document.getElementById('searchButton').addEventListener('click', searchProducts);
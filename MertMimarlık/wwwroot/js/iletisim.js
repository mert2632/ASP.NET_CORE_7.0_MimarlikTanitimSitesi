document.addEventListener("DOMContentLoaded", function () {
    var form = document.querySelector('.iletisimForm form');
    form.addEventListener('submit', function (event) {
        event.preventDefault();
        validateForm();
    });
});

function validateForm() {
    var adSoyad = document.querySelector('.iletisimForm input[placeholder="Adınızı giriniz."]').value;
    var email = document.querySelector('.iletisimForm input[placeholder="Mail adresinizi giriniz."]').value;
    var telefon = document.querySelector('.iletisimForm input[placeholder="Telefon numaranızı giriniz."]').value;
    var konu = document.querySelector('.iletisimForm input[placeholder="Konuyu giriniz."]').value;
    var mesaj = document.querySelector('.iletisimForm textarea').value;

    if (adSoyad.trim() === '' || email.trim() === '' || konu.trim() === '' || mesaj.trim() === '') {
        alert('Lütfen tüm zorunlu alanları doldurun.');
    } else if (!validatePhoneNumber(telefon)) {
        alert('Telefon numarası geçersiz. Lütfen 0 ile başlayan ve 11 haneli bir numara girin.');
    } else {
        // Formu gönderme işlemleri burada yapılabilir.
         return true;
        // form.submit(); // Eğer formu göndermek istiyorsanız bu satırı açabilirsiniz.
    }
}

function validatePhoneNumber(phoneNumber) {
    var phoneNumberRegex = /^(0\d{10})$/;
    return phoneNumberRegex.test(phoneNumber);
    return true;
}


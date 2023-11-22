
    function validateForm() {
        var password = document.getElementById("password").value;
        var confirmPassword = document.getElementById("confirmPassword").value;

        if (password !== confirmPassword) {
            alert("Şifreler eşleşmiyor. Lütfen doğru şifreyi girin.");
            return false; // Formun gönderilmesini engelle
        }

        return true; // Formu gönder
    }


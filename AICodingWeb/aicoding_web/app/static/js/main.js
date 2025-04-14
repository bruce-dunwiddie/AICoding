// Custom JavaScript for AICoding Web

// Initialize tooltips
document.addEventListener('DOMContentLoaded', function() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function(tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});

// Initialize popovers
document.addEventListener('DOMContentLoaded', function() {
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    var popoverList = popoverTriggerList.map(function(popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl);
    });
});

// Auto-hide alerts after 5 seconds
document.addEventListener('DOMContentLoaded', function() {
    var alerts = document.querySelectorAll('.alert:not(.alert-permanent)');
    alerts.forEach(function(alert) {
        setTimeout(function() {
            var bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        }, 5000);
    });
});

// Confirm delete actions
document.addEventListener('click', function(event) {
    if (event.target.matches('[data-confirm]')) {
        if (!confirm(event.target.getAttribute('data-confirm'))) {
            event.preventDefault();
        }
    }
});

// Form validation
document.addEventListener('DOMContentLoaded', function() {
    var forms = document.querySelectorAll('.needs-validation');
    Array.prototype.slice.call(forms).forEach(function(form) {
        form.addEventListener('submit', function(event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });
});

// Table sorting
document.addEventListener('DOMContentLoaded', function() {
    var tables = document.querySelectorAll('.table-sortable');
    tables.forEach(function(table) {
        var headers = table.querySelectorAll('th[data-sort]');
        headers.forEach(function(header) {
            header.addEventListener('click', function() {
                var column = header.getAttribute('data-sort');
                var order = header.getAttribute('data-order') === 'asc' ? 'desc' : 'asc';
                sortTable(table, column, order);
                header.setAttribute('data-order', order);
            });
        });
    });
});

function sortTable(table, column, order) {
    var tbody = table.querySelector('tbody');
    var rows = Array.from(tbody.querySelectorAll('tr'));
    var columnIndex = Array.from(table.querySelector('thead tr').children).findIndex(th => th.getAttribute('data-sort') === column);

    rows.sort(function(a, b) {
        var aValue = a.children[columnIndex].textContent;
        var bValue = b.children[columnIndex].textContent;

        if (order === 'asc') {
            return aValue.localeCompare(bValue);
        } else {
            return bValue.localeCompare(aValue);
        }
    });

    rows.forEach(function(row) {
        tbody.appendChild(row);
    });
}

// Handle dynamic form fields
document.addEventListener('DOMContentLoaded', function() {
    var addButtons = document.querySelectorAll('.add-form-field');
    addButtons.forEach(function(button) {
        button.addEventListener('click', function() {
            var template = document.querySelector(button.getAttribute('data-template'));
            var container = document.querySelector(button.getAttribute('data-container'));
            var clone = template.content.cloneNode(true);
            container.appendChild(clone);
        });
    });

    document.addEventListener('click', function(event) {
        if (event.target.matches('.remove-form-field')) {
            event.target.closest('.form-field').remove();
        }
    });
}); 
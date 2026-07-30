// Función simple para generar PDF
window.htmlToPdfSimple = async function (elementRef, fileName) {
    try {
        const options = {
            filename: `${fileName}.pdf`,
            margin: 1, // inches
            image: {
                type: 'jpeg',
                quality: 0.98
            },
            html2canvas: {
                scale: 2 
            },
            jsPDF: {
                unit: 'in', 
                format: 'letter',
                orientation: 'portrait' 
            }
        };
 
            // Call html2pdf() on the element and save the file
         html2pdf().set(options).from(elementRef).save();
        console.log('PDF generado exitosamente');

    } catch (error) {
        alert('Error al generar PDF:', error)
        console.error('Error al generar PDF:', error);
        throw error;
    }
};
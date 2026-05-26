// SalsaSimulator — app.js
// Funciones JS llamadas desde Blazor via IJSRuntime

// ── Gráfico Radar (MEJORA 3) ─────────────────────────────────────────────────
// Llamado desde Home.razor después de cada cálculo.
// Requiere Chart.js cargado en App.razor antes de este script.

window.renderRadar = (canvasId, labels, data) => {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    // Destruir instancia anterior si existe
    if (window._radarChart) {
        window._radarChart.destroy();
        window._radarChart = null;
    }

    const isDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

    const gridColor  = isDark ? 'rgba(255,255,255,0.08)' : 'rgba(0,0,0,0.08)';
    const labelColor = isDark ? '#a0aec0' : '#4a5568';
    const tickColor  = isDark ? '#718096' : '#a0aec0';

    window._radarChart = new Chart(ctx, {
        type: 'radar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Perfil de sabor',
                data: data,
                fill: true,
                backgroundColor: 'rgba(237, 137, 54, 0.15)',
                borderColor: '#ed8936',
                borderWidth: 2,
                pointBackgroundColor: '#ed8936',
                pointBorderColor: '#ed8936',
                pointHoverBackgroundColor: '#e53e3e',
                pointRadius: 4,
                pointHoverRadius: 6,
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            animation: {
                duration: 500,
                easing: 'easeOutQuart'
            },
            plugins: {
                legend: { display: false },
                tooltip: {
                    callbacks: {
                        label: (ctx) => ` ${ctx.raw}/10`
                    }
                }
            },
            scales: {
                r: {
                    min: 0,
                    max: 10,
                    ticks: {
                        stepSize: 2,
                        color: tickColor,
                        backdropColor: 'transparent',
                        font: { size: 10 }
                    },
                    grid: {
                        color: gridColor
                    },
                    angleLines: {
                        color: gridColor
                    },
                    pointLabels: {
                        color: labelColor,
                        font: { size: 11 }
                    }
                }
            }
        }
    });
};

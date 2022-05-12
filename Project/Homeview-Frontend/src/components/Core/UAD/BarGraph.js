import React from 'react';
import '../../../css/uad.css'
import { Bar } from "react-chartjs-2";
import { Chart as ChartJS } from 'chart.js/auto';

const BarGraph = ({ title, dataList }) => {
    const VIEW_LABELS = ["Home View", "Account View", "News View", "Movies View", "TV Shows View", "Streaming Service View", "ActWiki View"];
    const converted = (Object.values(dataList));
    let obj = {};

    // maps views to respective count
    for (var i = 0; i < VIEW_LABELS.length; i++) {
        obj[VIEW_LABELS[i]] = converted[i];
    };

    // sorts views from greatest to least
    let topFive = {};
    const sorted = Object.entries(obj).sort((a, b) => b[1] - a[1]);
    for (var i = 0; i < 5; i++) {
        topFive[sorted[i][0]] = sorted[i][1];
    }

    const labels = Object.keys(topFive);
    const dataset = {
        labels,
        datasets: [
            {
                label: "View Count",
                data: Object.values(topFive),
                fill: false,
                backgroundColor: "rgba(75,192,192,0.2)",
                borderColor: "rgba(75,192,192,1)"
            }
        ]
    };

    return (
        <div className="graph-container">
            <h3>{title}</h3>
            <Bar data={dataset} />
        </div>
    );
};
export default BarGraph;
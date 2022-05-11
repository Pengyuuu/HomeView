import React from 'react';
import '../../../css/uad.css'
import { Bar } from "react-chartjs-2";
import { Chart as ChartJS } from 'chart.js/auto';

// data = {2020-02-02: 5, etc}
const BarGraph = ({ title, dataList }) => {
    console.log(dataList);
    let xList = [];
    let yList = [];
    for (let x of Object.keys(dataList[0])) {
        xList.push(x);
    };
    for (let x of Object.values(dataList[0])) {
        yList.push(x);
    };
    const labels = xList;
    const dataset = {
        labels,
        datasets: [
            {
                label: "View Count",
                data: yList,
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
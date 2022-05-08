import React from 'react';
import Trend from 'react-trend';
import '../../../css/uad.css'


const TrendGraph = ({ title, dataList }) => (
    <div className="graph-container">
        <h3>{title}</h3>
        <Trend
            smooth
            autoDraw
            autoDrawDuration={3000}
            autoDrawEasing="ease-out"
            data={dataList}
            gradient={['#42b3f4']}
            radius={0}
            strokeWidth={2.1}
            strokeLinecap={'butt'}

        />

    </div>
);
export default TrendGraph;
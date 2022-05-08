import React from 'react';
import Trend from 'react-trend';
import '../../../css/uad.css'


const BarGraph = () => (
    <Trend
        smooth
        autoDraw
        autoDrawDuration={3000}
        autoDrawEasing="ease-out"
        data={[0, 2, 5, 9, 5, 10, 3, 5, 0, 0, 1, 8, 2, 9, 0]}
        gradient={['#00c6ff', '#F0F', '#FF0']}
        radius={10}
        strokeWidth={2}
        strokeLinecap={'square'}
    />
);
export default BarGraph;
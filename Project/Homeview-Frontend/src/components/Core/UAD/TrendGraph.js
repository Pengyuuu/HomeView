import React from 'react';
import Trend from 'react-trend';

const TrendGraph = ({dataList}) => (
    <Trend
        smooth
        autoDraw
        autoDrawDuration={3000}
        autoDrawEasing="ease-out"
        data={dataList}
        gradient={['#00c6ff', '#F0F', '#FF0']}
        radius={10}
        strokeWidth={2}
        strokeLinecap={'square'}
    />
);

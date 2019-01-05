import { Component, Inject } from '@angular/core';
import { StockChart, Chart } from 'angular-highcharts';
import { HttpClient } from '@angular/common/http';
import { IndividualSeriesOptions } from 'highcharts';

@Component({
    selector: 'app-assortment',
    templateUrl: './assortment.component.html',
    styleUrls: ['./assortment.component.css']
})
/** assortment component*/
export class AssortmentComponent {
  private _baseUrl: string;
  private _http: HttpClient;

  stock: StockChart;
  dataLoaded: boolean = true;
  myData: IndividualSeriesOptions[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  ngOnInit() {
    var someOtherVariable: Array<[number, number]> = [
      [Number(239), 47.08],
      [Number(240), 47.33],
      [Number(241), 47.71],
      [Number(242), 47.68],
      [Number(243), 48.02],
      [Number(246), 48.92],
      [Number(247), 48.81],
      [Number(247.2), 49.20],
      [Number(248), 49.38],
      [Number(249), 49.78],
      [Number(253), 48.66],
      [Number(253.2), 48.41],
      [Number(254), 47.53],
      [Number(255), 46.67],
      [Number(258), 48.21],
      [Number(259), 48.77],
    ];
    var someOtherVariable2: Array<[number, number]> = [
      [239, 37.08],
      [240, 37.33],
      [241, 37.71],
      [242, 37.68],
      [243, 38.02],
      [246, 38.92],
      [247, 38.81],
      [247.3, 39.20],
      [248, 39.38],
      [249, 39.78],
      [253, 38.66],
      [253.2, 38.41],
      [254, 37.53],
      [255, 36.67],
      [258, 38.21],
      [259, 38.77],
    ];

    var someOtherVariableTEST: Array<any> = [
      {
        x: 239,
        Y: 37.08,
        name:'239'
      },{
        x: 339,
        Y: 38.08,
        name: '339'
      }, {
        x: 439,
        Y: 39.08,
        name: '439'
      }, {
        x: 539,
        Y: 40.08,
        name: '539'
      }, {
        x: 639,
        Y: 41.08,
        name: '639'
      }, {
        x: 739,
        Y: 42.08,
        name: '739'
      }, {
        x: 839,
        Y: 43.08,
        name: '839'
      }, {
        x: 939,
        Y: 44.08,
        name: '939'
      },
    ];
    
    this.stock = new StockChart({
      chart: {
        type: 'spline',
        spacingBottom: 15,
        spacingTop: 25,
        spacingLeft: 10,
        spacingRight: 25
      },
      rangeSelector: {
        enabled: false        
      },
      title: {
        text: 'Charakterystyki dobranych wentylatorów'
      },
      tooltip: {
        split: true,        
        headerFormat: 'Wydajność: {point.x:.2f} [m3/h] <br>',
        pointFormat: 'Ciśnienie: {point.y} [Pa]',
        shared: true,
        crosshairs: [true, true]
      },
      navigator: {
        enabled: false,
        series: {
          visible: false,
          xAxis: 0
        }
      },
      xAxis: [
        {
        ordinal: false,
        allowDecimals: true,
        showLastLabel: false,
        gridLineWidth: 1,
       // minorTickInterval: 'auto',
       // minTickInterval: 0.01,
        tickAmount: 50,
        labels: {
          format: '{value} m3/h'
        },
        title: {
          text: 'Wydajność'
        }
        },
        {
          ordinal: false,
          allowDecimals: true,
          showLastLabel: false,
          gridLineWidth: 1,
          //  minorTickInterval: 'auto',
          //  minTickInterval: 0.01,
          //tickAmount: 50,
          tickInterval: 0.1,
          tickWidth: 0,
          labels: {
            formatter: function () {
              var xd = Number(this.value) / 1000;
              return xd + ' m3/s';
            }
          }
        }],
      yAxis: {        
        startOnTick: true,
        showFirstLabel: false,
        opposite: false,
        maxPadding: 0.35, 
        gridLineWidth: 1,
        title: {
          text: 'Ciśnienie'
        },
        labels: {
          format: '{value:.2f} Pa'
        }
      },
      plotOptions: {
        series: {          
          cursor: 'pointer',
          events: {
            click: function (e) {
              console.log(e);//TODO: Funkcja pokazuje informacje o wentylatorze
              alert(e.point.series.name);
            }
          }
        }
      },
      series: []
      /*[{
        name: 'AAPL',
        data: someOtherVariable,
        xAxis: 1
      },
        {
          name: 'AAPL2',
          data: someOtherVariable2,
          xAxis: 1
        }
      ]*/
    });
  }

  SearchForMatches() {
    
    var someOtherVariable: Array<[number, number]> = [
      [0.39, 47.08],
      [0.40, 47.33],
      [0.41, 47.71],
      [0.42, 47.68],
      [0.43, 48.02],
      [0.46, 48.92],
      [0.47, 48.81],
      [0.473, 49.20],
      [0.48, 49.38],
      [0.49, 49.78],
      [0.53, 48.66],
      [0.532, 48.41],
      [0.54, 47.53],
      [0.55, 46.67],
      [0.58, 48.21],
      [0.59, 48.77],
    ];
    var someOtherVariable: Array<[number, number]> = [
      [Number(239), 47.08],
      [Number(240), 47.33],
      [Number(241), 47.71],
      [Number(242), 47.68],
      [Number(243), 48.02],
      [Number(246), 48.92],
      [Number(247), 48.81],
      [Number(247.2), 49.20],
      [Number(248), 49.38],
      [Number(249), 49.78],
      [Number(253), 48.66],
      [Number(253.2), 48.41],
      [Number(254), 47.53],
      [Number(255), 46.67],
      [Number(258), 48.21],
      [Number(259), 48.77],
    ];
    var someOtherVariable2: Array<[number, number]> = [
      [239, 37.08],
      [240, 37.33],
      [241, 37.71],
      [242, 37.68],
      [243, 38.02],
      [246, 38.92],
      [247, 38.81],
      [247.3, 39.20],
      [248, 39.38],
      [249, 39.78],
      [253, 38.66],
      [253.2, 38.41],
      [254, 37.53],
      [255, 36.67],
      [258, 38.21],
      [259, 38.77],
    ];
    this.myData = [{
      name: 'AAPL',
      data: someOtherVariable,
    },
    {
      name: 'AAPL2',
      data: someOtherVariable2,
    }
    ];
    //this.stock.options.series = myData;
    this.stock.ref.addSeries(this.myData[0], true);
  }
}

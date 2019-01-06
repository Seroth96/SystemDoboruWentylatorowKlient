import { Component, Inject, ViewChild } from '@angular/core';
import { StockChart, Chart } from 'angular-highcharts';
import { HttpClient } from '@angular/common/http';
import { IndividualSeriesOptions } from 'highcharts';
import { WentylatorsApiService } from '../../services/wentylators-api.service';
import { isNullOrUndefined } from 'util';


@Component({
    selector: 'app-assortment',
    templateUrl: './assortment.component.html',
    styleUrls: ['./assortment.component.css']
})
/** assortment component*/
export class AssortmentComponent {
  Name: string;
  Nature: any;
  Power: string;
  Revolution: string;
  AirMassFlow: string;
  Pressure: string;
  natures: any;

  ModalContent: any;

  @ViewChild('myModal') myModal;

  stock: StockChart;
  dataLoaded: boolean = true;
  myData: IndividualSeriesOptions[];

  constructor(private WentylatorsApi: WentylatorsApiService, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.WentylatorsApi.getNatures().subscribe(response => {
      console.log(response.body);
      this.natures = response.body;
    },
      error => console.error(error),
      () => console.log('done')
    );
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
        pointFormat: 'Ciśnienie: {point.y:.2f} [Pa]',
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
      scrollbar: {
        enabled: false
      },
      xAxis: [
        {
          ordinal: false,
          allowDecimals: true,
          showLastLabel: true,
          gridLineWidth: 1,
          minTickInterval: 1,
          tickInterval: 20,
          tickWidth: 1,
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
          showLastLabel: true,
          gridLineWidth: 1,
          minTickInterval: 1,
          tickInterval: 20,
          tickWidth: 1,
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
          format: '{value} Pa'
        }
      },
      plotOptions: {
        series: {          
          cursor: 'pointer',
          events: {
            click: (e) => {
              var self = this;              
              console.log(e);        
              var params = [{
                name: "Id",
                value: e.point.series.options.id
              }];
              this.WentylatorsApi.getWentylator(params).subscribe(response => {
                console.log(response);
                self.ModalContent = response.body;
                self.openModel();
              },
                error => console.error(error),
                () => console.log('done')
              );
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

  SetParams() {
    var params = [];
    if (!isNullOrUndefined(this.Pressure)) {
      params.concat({
        name: "Pressure",
        value: this.Pressure
      });
    }
    if (!isNullOrUndefined(this.AirMassFlow)) {
      params.concat({
        name: "AirMassFlow",
        value: this.AirMassFlow
      });
    }
    if (!isNullOrUndefined(this.Name)) {
      params.concat({
        name: "Name",
        value: this.Name
      });
    }
    if (!isNullOrUndefined(this.Power)) {
      params.concat({
        name: "Power",
        value: this.Power
      });
    }
    if (!isNullOrUndefined(this.Revolution)) {
      params.concat({
        name: "Revolution",
        value: this.Revolution
      });
    }
    if (!isNullOrUndefined(this.Nature)) {
      params.concat({
        name: "Nature",
        value: this.Nature.name
      });
    }
    return params;
  }

  SearchForMatches() {
    var self = this;
    var params = this.SetParams();
    var wentylators: any;
    this.WentylatorsApi.getWentylators(params).subscribe(response => {
      console.log(response.body);
      wentylators = response.body;
      console.log(wentylators);
      //dla każdego wentylatora, wysłać zapytanie do controlera o dane do wykresu [X,Y]
      for (var i = 0; i < wentylators.length; i++) {
        var params = [{
          name: "Id",
          value: wentylators[i].id
        }];
        this.WentylatorsApi.getApproximationValues(params).subscribe(response => {
          console.log(response.body);
          var wentylator: any = response.body;
          console.log('Wentylator', wentylator);
          self.stock.ref.addSeries({
            name: wentylator.name,
            id: wentylator.id,
            data: wentylator.data,
            xAxis: 1
          }, true);
        },
          error => console.error(error),
          () => console.log('done')
        );
      } 
    },
      error => console.error(error),
      () => console.log('done')
    );
    
  }

  openModel() {
    this.myModal.nativeElement.className = 'modal show fade in';
  }
  closeModel() {
    this.myModal.nativeElement.className = 'modal hide';
  }

  config = {
    displayKey: "name", //if objects array passed which key to be displayed defaults to description
    search: true, //true/false for the search functionlity defaults to false,
            height: 'auto', //height of the list so that if there are more no of items it can show a scroll defaults to auto. With auto height scroll will never appear
            placeholder: 'Select', // text to be displayed when no item is selected defaults to Select,
            customComparator: () => { }, // a custom function using which user wants to sort the items. default is undefined and Array.sort() will be used in that case,
            limitTo: 8, // a number thats limits the no of options displayed in the UI similar to angular's limitTo pipe
            moreText: 'more', // text to be displayed whenmore than one items are selected like Option 1 + 5 more
            noResultsFound: 'No results found!', // text to be displayed when no items are found while searching
            searchPlaceholder: 'Wyszukaj', // label thats displayed in search input,
            searchOnKey: 'name' // key on which search should be performed this will be selective search. if undefined this will be extensive search on all keys
  }

  test() {
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
      id: '1',
      data: someOtherVariable,
    }
    ];
    //this.stock.options.series = myData;
    this.stock.ref.addSeries(this.myData[0], true);
  }
}

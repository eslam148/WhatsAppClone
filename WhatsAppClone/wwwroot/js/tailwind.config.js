function cal(n){
    return (n/20)*100;
}
tailwind.config = {
    theme: {
        
            container: {
                padding: '0rem',
            },
      extend: {
        backgroundImage: {
              'l-bg': "url('~/image/bgg.png')",
           },
        flexBasis: {
            '1/20': `${cal(1)}%`,
            '2/20': `${cal(2)}%`,
            '3/20': `${cal(3)}%`,
            '4/20': `${cal(4)}%`,
            '5/20': `${cal(5)}%`,
            '6/20': `${cal(6)}%`,
            '7/20': `${cal(7)}%`,
            '8/20': `${cal(8)}%`,
            '9/20': `${cal(9)}%`,
            '10/20': `${cal(10)}%`,
            '11/20': `${cal(11)}%`,
            '12/20': `${cal(12)}%`,
            '13/20': `${cal(13)}%`,
            '14/20': `${cal(14)}%`,
            '15/20': `${cal(15)}%`,
            '16/20': `${cal(16)}%`,
            '17/20': `${cal(17)}%`,
            '18/20': `${cal(18)}%`,
            '19/20': `${cal(19)}%`,
            '20/20': `${cal(20)}%`,


          }
      }
    }
  }
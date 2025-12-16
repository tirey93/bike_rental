export interface ThemeType {
  colors: {
    white: string;
    lightGrey: string;
    grey: string;
    darkGrey: string;
    black: string;
    success: string;
    error: string;
    warning: string;
    darkPurple: string;
    lightPurple: string;
  };
  fontSize: {
    xxl: string;
    xl: string;
    l: string;
    m: string;
    s: string;
  };
}

export const theme: ThemeType = {
  colors: {
    white: '#FFFFFF',
    lightGrey: '#F7F8FA',
    grey: '#C0C7D6',
    darkGrey: '#737C8E',
    black: '#111111',
    success: '#8FCB81',
    error: '#FF8383',
    warning: '#E1D888',
    darkPurple: '#C0C7D6',
    lightPurple: '#ECEFF7',
  },
  fontSize: {
    xxl: '34px',
    xl: '24px',
    l: '17px',
    m: '12px',
    s: '11px',
  },
};
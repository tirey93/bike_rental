import styled from 'styled-components';
import { ThemeType } from '../../assets/theme';

interface LabelProps {
  theme: ThemeType
}

export const Label = styled.label<LabelProps>`
  font-family: Montserrat, sans-serif;
  font-weight: bold;
  font-size: 12px;
  color: ${({ theme }) => theme.colors.darkGrey};
`;